using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HttpPostEx();
        }

        //https://blog.yowko.com/webrequest-and-httpwebrequest/
        public static void HttpGetEx()
        {
            WebRequest request = WebRequest.Create("http://jsonplaceholder.typicode.com/posts");
            request.Method = "GET";
            using (var httpResponse = (HttpWebResponse)request.GetResponse())

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine($"result:{result}");
            }
        }

        //https://reqbin.com/req/4rwevrqh/post-json-example
        public static void HttpPostEx()
        {
            WebRequest request = WebRequest.Create("https://reqbin.com/echo/post/json");
            request.Method = "POST";
            PostData postData = new PostData() { userId = 1, title = "yowko", body = "yowko test body 中文" };
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", "token apikey");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(postData);
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine($"result:{result}");
            }
        }
    }
}
