using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormServer
{
    public partial class Form1 : Form
    {
        private IPAddress _localAddress;
        private const int _port = 5656;
        private TcpListener _tcpListener;
        private BinaryWriter _bw;

        public Form1()
        {            
            InitializeComponent();
            _localAddress = IPAddress.Parse("127.0.0.1");

            //https://dotblogs.com.tw/kevintan1983/2010/10/15/18348
            IPEndPoint ipe = new IPEndPoint(_localAddress, _port);
            _tcpListener = new TcpListener(ipe);
            _tcpListener.Start();
            
            Thread myThread = new Thread(ListenClientConnect);
            myThread.IsBackground = true;
            myThread.Start();        
        }

        private void ListenClientConnect()
        {
            string text;
            DateTime now;
            text = string.Format("Wait Connect..");
            Debug.WriteLine(text);
            PrintTextToToolStripLabel(text, toolStripStatusLabel1);
            PrintTextToToolStripProgressBar(1, toolStripProgressBar1);

            while (true)
            {
                try
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();
                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.IsBackground = true;
                    receiveThread.Start(tcpClient);                    
                    receiveThread.Name = tcpClient.Client.RemoteEndPoint.ToString();

                    text = string.Format("Client Connect {0}", receiveThread.Name);
                    Debug.WriteLine(text);
                    PrintTextToToolStripLabel(text, toolStripStatusLabel1);
                    PrintTextToToolStripProgressBar(100, toolStripProgressBar1);
                    //show 1s
                    now = DateTime.Now;
                    while (now.AddSeconds(1) > DateTime.Now) { }
                }
                catch (Exception ex)
                {
                    text = string.Format("Stop Listen..{0}",ex.Message);
                    Debug.WriteLine(text);
                    PrintTextToToolStripLabel(text, toolStripStatusLabel1);
                    if (_tcpListener != null)
                    {
                        _tcpListener.Stop();
                    }

                    //show 1s
                    now = DateTime.Now;
                    while (now.AddSeconds(1) > DateTime.Now) { }

                    PrintTextToToolStripProgressBar(0, toolStripProgressBar1);
                    text = string.Format("Ready..");
                    PrintTextToToolStripLabel(text, toolStripStatusLabel1);
                    break;
                }
            }
        }

        private void ReceiveMessage(Object tcpClient)
        {
            Thread curThread = Thread.CurrentThread;
            TcpClient mytcpClient = (TcpClient)tcpClient;
            NetworkStream networkStream = mytcpClient.GetStream();
            BinaryReader br = new BinaryReader(networkStream);
            BinaryWriter bw = new BinaryWriter(networkStream);
            _bw = new BinaryWriter(networkStream);

            string text = "Server Say Hello";
            byte[] msgByte = Encoding.Default.GetBytes(text);
            bw.Write(msgByte, 0, msgByte.Length);
            bw.Flush();

            //https://stackoverflow.com/questions/15067014/c-sharp-detecting-tcp-disconnect
            // TcpClient / NetworkStream does not get notified when the connection is closed.
            // The only option available to you is to catch exceptions when writing to the stream.
            //while (mytcpClient.Connected == true)
            while (true)
            {
                try
                {
                    byte[] receiveBytes = new byte[mytcpClient.ReceiveBufferSize];
                    int numberOfBytesRead = 0;
                    string receiveMsg = "";
                    if (networkStream.CanRead)
                    {
                        do
                        {
                            numberOfBytesRead = br.Read(receiveBytes, 0, mytcpClient.ReceiveBufferSize);
                            receiveMsg = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                        }
                        while (networkStream.DataAvailable);
                        string strContent = string.Format("[Server Receive][{0}] {1} ", curThread.Name, receiveMsg);
                        Debug.WriteLine(strContent);

                        text = string.Format("[Client][{0}] {1}\r\n", curThread.Name, receiveMsg);
                        PrintTextToRichTextBox(text, richTextBox1);
                    }

                    ////https://stackoverflow.com/questions/15067014/c-sharp-detecting-tcp-disconnect
                    //check connect
                    //if client disconnect
                    if (mytcpClient.Client.Poll(1, SelectMode.SelectRead) && !networkStream.DataAvailable)
                    {
                        mytcpClient.GetStream().Close();
                        mytcpClient.Close();

                        text = string.Format("Wait Connect..");
                        Debug.WriteLine(text);
                        PrintTextToToolStripLabel(text, toolStripStatusLabel1);
                        PrintTextToToolStripProgressBar(0, toolStripProgressBar1);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    string strContent = string.Format("[Server Receive][{0}] {1} ", curThread.Name, ex.Message);
                    Debug.WriteLine(strContent);
                    mytcpClient.GetStream().Close();
                    mytcpClient.Close();

                    text = string.Format("Wait Connect..");
                    Debug.WriteLine(text);
                    PrintTextToToolStripLabel(text, toolStripStatusLabel1);
                    PrintTextToToolStripProgressBar(0, toolStripProgressBar1);
                    break;
                }
            }

            text = string.Format("[Server Receive][{0}] disconnect", curThread.Name);
            Debug.WriteLine(text);

            text = string.Format("disconnect..\r\n");
            PrintTextToRichTextBox(text, richTextBox1);
        }

        private void button1SendMessage_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if ((_bw != null) && (text != ""))
            {
                try
                {
                    string text1 = string.Format("[Server] {0}\r\n", text);
                    PrintTextToRichTextBox(text1, richTextBox1);

                    text1 = string.Empty;
                    PrintTextToTextBox(text1, textBox1);

                    byte[] msgByte = Encoding.Default.GetBytes(text);
                    _bw.Write(msgByte, 0, msgByte.Length);
                    _bw.Flush();
                }
                catch (Exception ex)
                {
                    text = string.Format("disconnect..{0}\r\n", ex.Message);
                    PrintTextToRichTextBox(text, richTextBox1);
                }
            }
        }
    }
}
