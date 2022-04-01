using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram
    {
    }
    public class Example
    {
        public static void test()
        {
            Console.WriteLine("Example Main");
            //CreateCustomSection();
            test();
        }
        public static void CreateCustomSection()
        {
            try
            {
                UrlsSection customSection = new UrlsSection();
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.Sections["CustomSection"] == null)
                {
                    config.Sections.Add("CustomSection", customSection);
                }
                customSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                Console.WriteLine("Created custom section in the application configuration file: {0}", config.FilePath);
                Console.WriteLine();
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("CreateCustomSection: {0}", err.ToString());
            }
        }
        public static void test2()
        {
            var config = (MySection)ConfigurationManager.GetSection("MySection");
            Assert.AreEqual("23", config.Code);
            Assert.AreEqual(2, config.Member.Id);
            Assert.AreEqual("余小章", config.Member.Name);
        }
    }

    //https://docs.microsoft.com/zh-tw/dotnet/api/system.configuration.configurationpropertyattribute?redirectedfrom=MSDN&view=dotnet-plat-ext-6.0
    public class UrlsSection : ConfigurationSection
    {
        [ConfigurationProperty("name", DefaultValue = "Contoso",
            IsRequired = true, IsKey = true)]
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
        [ConfigurationProperty("url", DefaultValue = "http://www.contoso.com",
            IsRequired = true)]
        [RegexStringValidator(@"\w+:\/\/[\w.]+\S*")]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }
        [ConfigurationProperty("port", DefaultValue = (int)0, IsRequired = false)]
        [IntegerValidator(MinValue = 0, MaxValue = 8080, ExcludeRange = false)]
        public int Port
        {
            get
            {
                return (int)this["port"];
            }
            set
            {
                this["port"] = value;
            }
        }
    }

    //https://dotblogs.com.tw/yc421206/2015/06/19/151599
    public class MySection : ConfigurationSection
    {
        private MySection()
        {

        }
        [ConfigurationProperty("Code", DefaultValue = "9527")]
        public string Code
        {
            get { return this["Code"].ToString(); }
            set { this["Code"] = value; }
        }
        [ConfigurationProperty("Member")]
        public MemberElement Member
        {
            get { return (MemberElement)this["Member"]; }
            set { this["Member"] = value; }
        }
    }
    public class MemberElement : ConfigurationElement
    {
        [ConfigurationProperty("Id", DefaultValue = 2)]
        public int Id
        {
            get { return (int)this["Id"]; }
            set { this["Id"] = value; }
        }
        [ConfigurationProperty("Name", DefaultValue = "Yao")]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }
    }
}
