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

namespace WinFormClient
{
    public partial class Form1 : Form
    {
        private const int _port = 5656;
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private BinaryReader _br;
        private BinaryWriter _bw;


        public Form1()
        {
            InitializeComponent();

            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonSendMessage.Enabled = false;
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            string text = textBoxSendMsg.Text;
            if (text != "")
            {
                string text1 = string.Format("[Client Send] {0} ", text);
                Debug.WriteLine(text1);

                text1 = string.Format("[Client] {0}\r\n", text);
                PrintTextToRichTextBox(text1, richTextBox1);

                text1 = string.Empty;
                PrintTextToTextBox(text1, textBoxSendMsg);

                try
                {
                    byte[] msgByte = Encoding.Default.GetBytes(text);
                    _bw.Write(msgByte, 0, msgByte.Length);
                    _bw.Flush();                    
                }
                catch(Exception ex)
                {

                    text = string.Format("disconnect..{0}\r\n",ex.Message);
                    PrintTextToRichTextBox(text, richTextBox1);

                    _tcpClient.GetStream().Close();
                    _tcpClient.Close();
                    buttonConnect.Enabled = true;
                    buttonDisconnect.Enabled = false;
                    buttonSendMessage.Enabled = false;                    
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            
            string text = "";
            DateTime now;
            try
            {
                text = string.Format("Connect...");
                Debug.WriteLine(text);
                PrintTextToToolStripLabel(text, toolStripStatusLabel1);
                PrintTextToToolStripProgressBar(1, toolStripProgressBar1);

                _tcpClient = new TcpClient();
                IPHostEntry remoteHost = Dns.GetHostEntry(textBoxServerIP.Text);
                _tcpClient.Connect(remoteHost.HostName, _port);

                PrintTextToToolStripProgressBar(100, toolStripProgressBar1);
                //show 1s
                now = DateTime.Now;
                while (now.AddSeconds(1) > DateTime.Now) { }

                text = string.Format("Connect Success");
                Debug.WriteLine(text);
                PrintTextToToolStripLabel(text, toolStripStatusLabel1);
            }
            catch(Exception ex)
            {
                text = string.Format("Connect fail..{0} ", ex.Message);
                Debug.WriteLine(text);
                PrintTextToToolStripLabel(text, toolStripStatusLabel1);

               
                //show 1s
                now = DateTime.Now;
                while (now.AddSeconds(1) > DateTime.Now) { }
                PrintTextToToolStripProgressBar(0, toolStripProgressBar1);

                return;
            }

            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            buttonSendMessage.Enabled = true;

            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.IsBackground = true;
            receiveThread.Start(_tcpClient);
            receiveThread.Name = _tcpClient.Client.RemoteEndPoint.ToString();

            text = string.Format("[Client] connect to  {0} ", receiveThread.Name);
            Debug.WriteLine(text);

            _networkStream = _tcpClient.GetStream();
            _br = new BinaryReader(_networkStream);
            _bw = new BinaryWriter(_networkStream);
        }

        private void ReceiveMessage(Object tcpClient)
        {
            Thread curThread = Thread.CurrentThread;
            TcpClient mytcpClient = (TcpClient)tcpClient;
            NetworkStream networkStream = mytcpClient.GetStream();
            BinaryReader br = new BinaryReader(networkStream);
            BinaryWriter bw = new BinaryWriter(networkStream);

            string text = "Client Say Hello";
            byte[] msgByte = Encoding.Default.GetBytes(text);
            bw.Write(msgByte, 0, msgByte.Length);
            bw.Flush();

            while (true)
            {
                try
                {
                    byte[] receiveBytes = new byte[mytcpClient.ReceiveBufferSize];
                    int numberOfBytesRead = 0;
                    string receiveMsg = "";
                    if (networkStream.CanRead && networkStream.DataAvailable)
                    {
                        do
                        {
                            numberOfBytesRead = br.Read(receiveBytes, 0, mytcpClient.ReceiveBufferSize);
                            receiveMsg = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                        }
                        while (networkStream.DataAvailable);
                        string strContent = string.Format("[Client Receive][{0}] {1} ", curThread.Name, receiveMsg);
                        Debug.WriteLine(strContent);

                        text = string.Format("[Server][{0}] {1}\r\n", curThread.Name, receiveMsg);
                        PrintTextToRichTextBox(text, richTextBox1);
                    }
                }
                catch (Exception ex)
                {
                    string strContent = string.Format("[Client Receive][{0}] {1} ", curThread.Name, ex.Message);
                    Debug.WriteLine(strContent);
                    break;
                }
            }

        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if(_tcpClient != null)
            {
                //https://stackoverflow.com/questions/425235/how-to-properly-and-completely-close-reset-a-tcpclient-connection
                _tcpClient.GetStream().Close();
                _tcpClient.Close();
            }
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonSendMessage.Enabled = false;

            string text = string.Format("Ready...");
            Debug.WriteLine(text);
            PrintTextToToolStripLabel(text, toolStripStatusLabel1);
            PrintTextToToolStripProgressBar(0, toolStripProgressBar1);
        }
    }
}
