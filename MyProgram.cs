using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram
    {
    }
    abstract class FileProcessor
    {
        public abstract string Open();
        public void Close()
        {
            Console.WriteLine("Close file, Close()");
        }

        ~FileProcessor()
        {
            Console.WriteLine("Object release, ~FileProcessor()");
        }
    }

    class XMLFileProcessor : FileProcessor
    {
        public override string Open()
        {
            return "Open XML File";
        }
    }

    class TXTFileProcessor : FileProcessor
    {
        public override string Open()
        {
            return "Open TXT File";
        }
    }
    class XLSFileProcessor : FileProcessor
    {
        public override string Open()
        {
            return "Open XLS File";
        }
    }

    static class FileProcessorFactory
    {
        public static FileProcessor getInstance(string fileformat)
        {
            switch (fileformat)
            {
                case "TXT":
                    return new TXTFileProcessor();
                case "XML":
                    return new XMLFileProcessor();
                case "XLS":
                    return new XLSFileProcessor();
                default:
                    return new TXTFileProcessor();
            }
        }
    }
}
