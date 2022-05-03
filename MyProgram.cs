using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    class MyProgram
    {
    }
    public class Example
    {
        public void Main()
        {
            Console.WriteLine("Example Main");
        }
    }
    public interface iDatabase
    {
        void save();
    }
    public class clsSQLServer : iDatabase
    {
        public void save()
        {
            MessageBox.Show("Saving to SQL Server Database now.","clsSQLServer");
        }
    }
    public class clsOracle : iDatabase
    {
        public void save()
        {
            MessageBox.Show("Saving to Oracle DataBase now.","clsOracle");
        }
    }
    public class AccessDBEngine
    {
        private iDatabase idatabase;
        public AccessDBEngine()
        {
            this.idatabase = null;
        }
        public AccessDBEngine(iDatabase database)
        {
            this.idatabase = database;
        }
        public iDatabase Database
        {
            get { return idatabase; }
            set { idatabase = value; }
        }
        public void save()
        {
            idatabase.save()；
        }
        public void setDatabase(iDatabase database)
        {
            this.idatabase = database;
        }
    }

    //https://docs.microsoft.com/zh-tw/dotnet/api/system.configuration.configurationelementcollection?view=dotnet-plat-ext-6.0
    //https://dotblogs.com.tw/yc421206/2015/06/19/151599
    //.NET 的組態檔(App.config |Web.config)內建提供一些區段，它可以讓我們存放應用程式的參數

    public class DatabasePoolSection : ConfigurationSection
    {
        [ConfigurationProperty("",IsRequired =true,IsDefaultCollection =true)]
        public string Code
        {
            get { return this["Code"].ToString(); }
            set { this["Code"] = value; }
        }
    }

    public class DatabasePoolElementCollection : ConfigurationElementCollection
    {
        //ConfigurationElementCollection: 要實做GetElementKey介面
        protected override string ElementName
        {
            get
            {
                return "databasePool";
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new DatbasePoolElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabasePoolElementCollection)element).ElementName;
        }
        public DatbasePoolElement this[int index]
        {
            get
            {
                return (DatbasePoolElement)BaseGet(index);
            }
            set
            {
                if(BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
            }
        }
        public DatbasePoolElement this[string name]
        {
            get
            {
                return (DatbasePoolElement)BaseGet(name);
            }
        }
    }
    public class DatbasePoolElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
        [ConfigurationProperty("maxpoolcount", IsRequired = true)]
        public int MaxPoolCount
        {
            get
            {
                return (int)this["maxpoolcount"];
            }
            set
            {
                this["maxpoolcount"] = value;
            }
        }
    }
}
