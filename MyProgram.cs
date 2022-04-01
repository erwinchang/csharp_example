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
            CreateCustomSection();
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
}
