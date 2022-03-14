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
    public abstract class SourceStrategy
    {
        public iFindString IFindString;
        public SourceStrategy() { }
        public SourceStrategy(iFindString fs)
        {
            this.IFindString = fs;
        }
        public void runFindString()
        {
            IFindString.FindString();
        }
        public void setIFindString(iFindString fb)
        {
            IFindString = fb;
        }
    }
    public interface iFindString
    {
        void FindString();
    }

    public class SQLSource : SourceStrategy
    {
        public SQLSource()
        {
            this.IFindString = new FindWithSQL();
        }
    }

    public class HBaseSource : SourceStrategy
    {
        public HBaseSource()
        {
            this.IFindString = new FindWithHBase();
        }
        public HBaseSource(String DBType)
        {
            if(DBType == "Cassandra")
            {
                this.IFindString = new FindWithBigData();
            }
            else
            {
                this.IFindString = new FindWithHBase();
            }
        }
    }

    public class FindWithSQL : iFindString
    {
        public void FindString()
        {
            Console.WriteLine("String finding from SQL !!, FindWithSQL");
        }
    }
    public class FindWithHBase : iFindString
    {
        public void FindString()
        {
            Console.WriteLine("String finding from HBase !!, FindWithHBase");
        }
    }
    public class FindWithBigData : iFindString
    {
        public void FindString()
        {
            Console.WriteLine("String finding from BigData !!, FindWithBigData");
        }
    }
}
