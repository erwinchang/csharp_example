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
    }
}
