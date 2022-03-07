using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

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
            //Create a new XslCompiledTransform and load the compiled transformation.
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(typeof(Transform));

            String srcXmlFile = @"D:\gitWork\test-xml-xslt\books.xml";
            String resHtmlFile = @"D:\gitWork\test-xml-xslt\discount_books.html";
            // Execute the transformation and output the results to a file.
            //xslt.Transform("books.xml", "discount_books.html");
            xslt.Transform(srcXmlFile, resHtmlFile);
        }
    }
}
