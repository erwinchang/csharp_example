using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public delegate void AddListItem(String myString);
        public AddListItem myDelegate;
        private Thread myThread;
        public Form1()
        {
            InitializeComponent();
            myDelegate = new AddListItem(AddListItemMethod);
        }
        private void Test()
        {
            textBox1.AppendText("Hello" + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread = new Thread(Test);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myThread = new Thread(new ThreadStart(ThreadFunction));
            myThread.Start();
        }
        private void ThreadFunction()
        {
            MyThreadClass myThreadClassObject = new MyThreadClass(this);
            myThreadClassObject.Run();
        }

        public void AddListItemMethod(String myString)
        {
            listBox1.Items.Add(myString);
            Console.WriteLine($"Form1.AddListItemMethod: {myString}");
        }
    }
    //https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.control.invoke?view=windowsdesktop-6.0
    public class MyThreadClass
    {
        Form1 myform1;
        String myString;

        public MyThreadClass(Form1 myfrm)
        {
            myform1 = myfrm;
        }

        public void Run()
        {
            for (int i = 1; i <= 5; i++)
            {
                myString = "Step number " + i.ToString() + " executed";
                Console.WriteLine($"MyThreadClass Run: {myString}");
                Thread.Sleep(400);

                myform1.Invoke(myform1.myDelegate, new Object[] { myString });
            }
            
        }
    }
}
