using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            String xml = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><Device xmlns=\"http://www.lxistandard.org/InstrumentIdentification/1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.lxistandard.org/InstrumentIdentification/1.0\"><Manufacturer>ROHDE&amp;SCHWARZ</Manufacturer><Model>HMP2020</Model><SerialNumber>102523</SerialNumber><FirmwareRevision>2.70</FirmwareRevision><ManufacturerDescription>Rohde &amp; Schwarz GmbH &amp; Co. KG</ManufacturerDescription><HomepageURL>www.rohde-schwarz.com</HomepageURL><DriverURL>www.rohde-schwarz.com</DriverURL><UserDescription>R&amp;S HMP2020-102523</UserDescription><IdentificationURL>http://192.168.1.10/lxi/identifcation</IdentificationURL><Interface xsi:type=\"NetworkInformation\" InterfaceType=\"VXI\" IPType=\"IPv4\" InterfaceName=\"eth0\"><InstrumentAddressString>TCPIP::192.168.1.10::INSTR</InstrumentAddressString><InstrumentAddressString>TCPIP::192.168.1.10::5025::SOCKET</InstrumentAddressString><Hostname>192.168.1.10</Hostname><IPAddress>192.168.1.10</IPAddress><SubnetMask>255.255.255.0</SubnetMask><MACAddress>00-90-B8-23-D2-6E</MACAddress><Gateway>192.168.1.1</Gateway><DHCPEnabled>false</DHCPEnabled><AutoIPEnabled>false</AutoIPEnabled></Interface></Device>";
            TxtXML.Text = xml;
        }

        private void BtnXMLParse_Click(object sender, EventArgs e)
        {
            String xml = TxtXML.Text;
        }
    }
}
