# csharp_example

## 如何新增csharp_example.exe.config/CustomSection


```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
        <section name="CustomSection" type="csharp_example.UrlsSection, csharp_example, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
    </configSections>
    <CustomSection name="Contoso" url="http://www.contoso.com" />
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>
</configuration>
```

1.定義UrlsSection

```
    public class UrlsSection : ConfigurationSection
    {
        [ConfigurationProperty("name", DefaultValue = "Contoso",
```

2.寫入

```
UrlsSection customSection = new UrlsSection();
System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

if (config.Sections["CustomSection"] == null)
{
    config.Sections.Add("CustomSection", customSection);
}
```

[ConfigurationPropertyAttribute 類別][1]

[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.configuration.configurationpropertyattribute?redirectedfrom=MSDN&view=dotnet-plat-ext-6.0