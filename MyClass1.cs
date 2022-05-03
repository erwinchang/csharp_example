using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    class MyClass1
    {
    }

    //https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.applicationcontext?view=windowsdesktop-6.0
    public class AppForm2 : System.Windows.Forms.Form
    {
        public AppForm2()
        {
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "AppForm2";
        }
    }
    public class AppForm1 : System.Windows.Forms.Form
    {
        public AppForm1()
        {
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "AppForm1";
        }
    }
    class MyApplicationContext : ApplicationContext
    {
        private int _formCount;
        private AppForm1 _form1;
        private AppForm2 _form2;

        private Rectangle _form1Position;
        private Rectangle _form2Position;

        private FileStream _userData;

        private MyApplicationContext()
        {
            _formCount = 0;

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            Console.WriteLine($"UserAppDataPath:{Application.UserAppDataPath}");
            try
            {
                _userData = new FileStream(Application.UserAppDataPath + "\\appdata.txt", FileMode.OpenOrCreate);
            }
            catch(IOException e)
            {
                MessageBox.Show("An error occurred while attempting to show the application." +
                                "The error is:" + e.ToString());
                ExitThread();
            }

            _form1 = new AppForm1();
            _form1.Closed += new EventHandler(OnFormClosed);
            _form1.Closing += new CancelEventHandler(OnFormClosing);
            _formCount++;

            _form2 = new AppForm2();
            _form2.Closed += new EventHandler(OnFormClosed);
            _form2.Closing += new CancelEventHandler(OnFormClosing);
            _formCount++;

            if (ReadFormDataFromFile())
            {
                _form1.StartPosition = FormStartPosition.Manual;
                _form2.StartPosition = FormStartPosition.Manual;

                _form1.Bounds = _form1Position;
                _form2.Bounds = _form2Position;
            }

            _form1.Show();
            _form2.Show();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            WriteFormDataToFile();
            try
            {
                _userData.Close();
            }
            catch { }
        }

        private bool WriteFormDataToFile()
        {
            UTF8Encoding encoding = new UTF8Encoding();
            RectangleConverter rectConv = new RectangleConverter();
            string form1pos = rectConv.ConvertToString(_form1Position);
            string form2pos = rectConv.ConvertToString(_form2Position);
            byte[] dataToWrite = encoding.GetBytes("~" + form1pos + "~" + form2pos);
            try
            {
                _userData.Seek(0, SeekOrigin.Begin);
                _userData.Write(dataToWrite, 0, dataToWrite.Length);
                _userData.Flush();

                _userData.SetLength(dataToWrite.Length);
                return true;

            }
            catch
            {
                return false;
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            _formCount--;
            if (_formCount == 0)
            {
                ExitThread();
            }
        }

        private void OnFormClosing(object sender, CancelEventArgs e)
        {
            if (sender is AppForm1)
                _form1Position = ((Form)sender).Bounds;
            else if (sender is AppForm2)
                _form2Position = ((Form)sender).Bounds;
        }

        private bool ReadFormDataFromFile()
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string data;

            if (_userData.Length != 0)
            {
                byte[] dataToRead = new byte[_userData.Length];
                try
                {
                    _userData.Seek(0, SeekOrigin.Begin);
                    _userData.Read(dataToRead, 0, dataToRead.Length);
                }
                catch (IOException e)
                {
                    string errorInfo = e.ToString();
                    return false;
                }

                data = encoding.GetString(dataToRead);

                try
                {
                    RectangleConverter rectConv = new RectangleConverter();
                    string form1pos = data.Substring(1, data.IndexOf("~", 1) - 1);
                    _form1Position = (Rectangle)rectConv.ConvertFromString(form1pos);

                    string form2pos = data.Substring(data.IndexOf("~", 1) + 1);
                    _form2Position = (Rectangle)rectConv.ConvertFromString(form2pos);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            MyApplicationContext context = new MyApplicationContext();
            Application.Run(context);
        }
    }
}
