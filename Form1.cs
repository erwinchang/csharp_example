using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			testXML();
		}
		public void testXML()
		{
			//https://medium.com/%E7%A8%8B%E5%BC%8F%E8%A3%A1%E6%9C%89%E8%9F%B2/c-xml-to-json-23e16a3a3880
			XmlDocument xmlDoc = new XmlDocument();
			String file = @"D:\test.xml";
			xmlDoc.Load(file);

			string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
			Response response = JsonConvert.DeserializeObject<Response>(jsonText);
			Console.WriteLine("response " + response.ToString());
			Console.WriteLine("tt11");
		}
	}



	public class Response
	{
		[JsonProperty(PropertyName = "Head")]
		Head head;
	}

	internal class Head
	{
		[JsonProperty(PropertyName = "param")]
		List<Param> paramList;
	}

	internal class Param
	{
		[JsonProperty(PropertyName = "@name")]
		string name;
		[JsonProperty(PropertyName = "#text")]
		string text;
	}
}
