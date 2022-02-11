using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnXMLFile_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/how-to-open-files-using-the-openfiledialog-component?view=netframeworkdesktop-4.8
            OpenFileDialog  openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            String file = openFileDialog1.FileName;
            TxtXMLFile.Text = file;
            Console.WriteLine($"file:{file}");
            ParseXML(file);
        }

        //https://dotnetcoretutorials.com/2020/04/23/how-to-parse-xml-in-net-core/
        public static void ParseXML(String file)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (var fileStream = File.OpenText(file))
            using (XmlReader reader = XmlReader.Create(fileStream, settings))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    { 
                        case XmlNodeType.Element:
                            Console.WriteLine($"Start Element: {reader.Name}. Has Attributes? : {reader.HasAttributes}");
                            break;
                        case XmlNodeType.Text:
                            Console.WriteLine($"Inner Text: {reader.Value}");
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine($"End Element: {reader.Name}");
                            break;
                        default:
                            Console.WriteLine($"Unknown: {reader.NodeType}");
                            break;
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              String xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Device xmlns=\"http://www.lxistandard.org/InstrumentIdentification/1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.lxistandard.org/InstrumentIdentification/1.0\"><Manufacturer>ROHDE&amp;SCHWARZ</Manufacturer><Model>HMP2020</Model><SerialNumber>102523</SerialNumber><FirmwareRevision>2.70</FirmwareRevision><ManufacturerDescription>Rohde &amp; Schwarz GmbH &amp; Co. KG</ManufacturerDescription><HomepageURL>www.rohde-schwarz.com</HomepageURL><DriverURL>www.rohde-schwarz.com</DriverURL><UserDescription>R&amp;S HMP2020-102523</UserDescription><IdentificationURL>http://192.168.1.10/lxi/identifcation</IdentificationURL><Interface xsi:type=\"NetworkInformation\" InterfaceType=\"VXI\" IPType=\"IPv4\" InterfaceName=\"eth0\"><InstrumentAddressString>TCPIP::192.168.1.10::INSTR</InstrumentAddressString><InstrumentAddressString>TCPIP::192.168.1.10::5025::SOCKET</InstrumentAddressString><Hostname>192.168.1.10</Hostname><IPAddress>192.168.1.10</IPAddress><SubnetMask>255.255.255.0</SubnetMask><MACAddress>00-90-B8-23-D2-6E</MACAddress><Gateway>192.168.1.1</Gateway><DHCPEnabled>false</DHCPEnabled><AutoIPEnabled>false</AutoIPEnabled></Interface></Device>";
            //string xml = "\t\t\t\t\t\t\t\t\t\t\t\t<?xml version=\"1.0\" encoding=\"UTF-8\"?><documents><Resp><Id>486441f5-7fa6-4676-b37d-ef29cfbdb1fe</Id><accountId>yowko</accountId><orderNo>Yowko16111800018</orderNo><mtaTransId>8800000006293669</mtaTransId><transAmt>3</transAmt><result>0000</result><respCode>0</respCode><transTime>20161118143324</transTime><completeTime>20161118150716</completeTime></Resp></documents>";
            TxtXML.Text = xml;

            //http://pertonchang.blogspot.com/2018/04/c-xml.html
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Device");

            string t1 = nodes[0].SelectSingleNode("Manufacturer").InnerText;
            string t2 = nodes[0].SelectSingleNode("Model").InnerText;
            string t3 = nodes[0].SelectSingleNode("SerialNumber").InnerText;
        }

        private void BtnXMLParse_Click(object sender, EventArgs e)
        {
            String xml = TxtXML.Text;
            ParseXMLString(xml);
        }

        public static void ParseXMLString(String xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(HttpUtility.HtmlDecode(xml).Trim());
            var res = doc.GetElementsByTagName("Manufacturer");
            int i = 0;
            i = 1;
        }
    }
}
