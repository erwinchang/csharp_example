using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        //https://dotblogs.com.tw/masterhsu/2016/06/21/225343
        private SerialPort My_SerialPort;
        private bool Console_receiving = false;
        private Thread t;
        //使用委派顯示 Console 畫面
        delegate void Display(string buffer);

        public Form1()
        {
            InitializeComponent();
        }

        public void ConsoleShow(string buffer)
        {
            TxtOutput.AppendText(buffer);
        }

        public void Console_Connect(string COM, Int32 baud)
        {
            try
            {
                My_SerialPort = new SerialPort();
                if (My_SerialPort.IsOpen)
                    My_SerialPort.Close();

                My_SerialPort.PortName = COM;
                My_SerialPort.BaudRate = baud;
                My_SerialPort.DataBits = 8;
                My_SerialPort.StopBits = StopBits.One;

                My_SerialPort.Open();
                Console_receiving = true;
                t = new Thread(DoReceive);
                t.IsBackground = true;
                t.Start();
                Console.WriteLine($"Connect...COM:{COM},Baud:{baud}");
                BtnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CloseComport()
        {
            try
            {
                My_SerialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Console 接收資料
        private void DoReceive()
        {
            Byte[] buffer = new Byte[1024];

            try
            {
                while (Console_receiving)
                {
                    if (My_SerialPort.BytesToRead > 0)
                    {
                        Int32 length = My_SerialPort.Read(buffer, 0, buffer.Length);

                        string buf = Encoding.ASCII.GetString(buffer);

                        Array.Resize(ref buffer, length);
                        Display d = new Display(ConsoleShow);
                        this.Invoke(d, new Object[] { buf });
                        Array.Resize(ref buffer, 1024);
                    }

                    Thread.Sleep(20);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Console 發送資料
        public void SendData(Object sendBuffer)
        {
            if (sendBuffer != null)
            {
                Byte[] buffer = sendBuffer as Byte[];

                try
                {
                    My_SerialPort.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    CloseComport();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendData(Encoding.ASCII.GetBytes(TxtInput.Text + "\r\n"));
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Console_Connect("COM3", 115200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnSend.Enabled = false;
        }
    }
}
