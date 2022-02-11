using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnHttpGET_Click(object sender, EventArgs e)
        {
            HttpGetEx01();
        }
        public async static void  HttpGetEx01()
        {
            //https://www.1024sou.com/article/75699.html
            //string text = await "http://jsonplaceholder.typicode.com/posts".GetStringAsync();
            //Console.WriteLine(text);

            //var url = "http://jsonplaceholder.typicode.com"
            //.AppendPathSegment("posts");

            var url = "http://192.168.10.10"
            .AppendPathSegment("scpictrl.htm")
            .SetQueryParams(new
            {
                lang = "en",
                request = "*IDN?",
                cmd = "Send"
            });

            string text1 = await url
                            .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                            .GetStringAsync();

            Console.WriteLine(text1);
            int i = 1;
        }
    }
}
