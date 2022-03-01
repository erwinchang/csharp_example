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


---------------


```
<?xml version="1.0" encoding="utf-8"?>
<TestPlan PlanID="RF_Thermal_" Description = "RF Thermal TestPlan">
  <TestCase CaseID="1" XTTFileName="QCC5100_Validation_WIFI_V1_KY_1229-OnlyDUT.xtt" Temperature="55" Voltage="3.3" />
  <TestCase CaseID="2" XTTFileName="QCC5100_Validation_WIFI_V1_KY_1229-OnlyDUT.xtt" Temperature="25" Voltage="3.3" />
  <TestCase CaseID="3" XTTFileName="QCC5100_Validation_WIFI_V1_KY_1229-OnlyDUT.xtt" Temperature="-10" Voltage="3.3" />
</TestPlan>
```

```
	public class Response
	{
		[JsonProperty(PropertyName = "TestPlan")]
		TestPlan testplan;
	}

	internal class TestPlan
	{
		[JsonProperty(PropertyName = "@PlanID")]
		string planid;

		[JsonProperty(PropertyName = "@Description")]
		string description;

		[JsonProperty(PropertyName = "TestCase")]
		List<TestCase> testcaseList;
	}

	internal class TestCase
	{
		[JsonProperty(PropertyName = "@CaseID")]
		string caseid;

		[JsonProperty(PropertyName = "@XTTFileName")]
		string xttfilename;

		[JsonProperty(PropertyName = "@Temperature")]
		string Temperature;

		[JsonProperty(PropertyName = "@Voltage")]
		string Voltage;
	}
```

<a href="https://imgur.com/gyZ59kP"><img src="https://i.imgur.com/gyZ59kP.png" title="source: imgur.com" width="400" /></a>


[1]:https://medium.com/%E7%A8%8B%E5%BC%8F%E8%A3%A1%E6%9C%89%E8%9F%B2/c-xml-to-json-23e16a3a3880