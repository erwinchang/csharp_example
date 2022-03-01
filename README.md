# csharp_example

## [C# XML to JSON][1]


D:\test.xml
```
<?xml version="1.0" encoding="utf-8"?>
<Head>
    <param name="DATE">20190906</param>
    <param name="TIME">235959</param>
    <param name="RETURN_CODE">XXXX</param>
    <param name="RETURN_MSG">XXXX</param>
</Head>
```

```
public class Response
{
	[JsonProperty(PropertyName = "Head")]
	Head head;
}
internal class Head
{
	[JsonProperty(PropertyName = "param")]
	List<Param> paramList;
}
internal class Param
{
	[JsonProperty(PropertyName = "@name")]
	string name;
	[JsonProperty(PropertyName = "#text")]
	string text;
}

```

<a href="https://imgur.com/eXhlqn6"><img src="https://i.imgur.com/eXhlqn6.png" title="source: imgur.com" width="400" /></a>

[1]:https://medium.com/%E7%A8%8B%E5%BC%8F%E8%A3%A1%E6%9C%89%E8%9F%B2/c-xml-to-json-23e16a3a3880