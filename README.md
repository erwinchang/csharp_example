# csharp_example

## 如何自制NLog Target

NLog.config如下  
下例extensions表示會載入的NLOG.Slack.dll  
因此Target Slack是定義在NLOG.Slack.dll裡面  
```
<extensions>
<add assembly="NLOG.Slack"/>
</extensions>
<targets>
<target name="Slack" xsi:type="Slack"
webhookUrl="https://hooks.slack.com/services/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"
layout="${message}" />
<target
xsi:type="File"
name="f"
fileName="${basedir}/logs/${shortdate}.log"
layout="${longdate}|${level:uppercase=true}|${logger}|${message}" />
</targets>
<rules>
<logger name="*" minlevel="Debug" writeTo="f" />
<logger name="*" minlevel="Debug" writeTo="Slack" />
</rules>
```

```
namespace NLog.Targets
{
[Target("Slack")] //=>這個是 定義NLog Target的方法
public class SlackTarget : TargetWithLayout
{
[RequiredParameter]
public string WebhookUrl { get; set; }

protected override void Write(LogEventInfo logEvent)
{
var hostName = Environment.MachineName;
var appDomain = AppDomain.CurrentDomain;
var renderedLog = this.RenderLogEvent(this.Layout, logEvent);

var title = $"[{logEvent.Level.ToString().ToUpper()}] on {hostName}";
var Color = GetColor(logEvent.Level);

String filepath = @"D:\nlog.txt";
String msg = $"hostName:{hostName}, appDomain:{appDomain}, renderedLog:{renderedLog}, title:{title}, Color:{Color},WebhookUrl:{WebhookUrl}";
System.IO.File.AppendAllText(filepath, msg);
```

產生log內容如下  
WebhookUrl是直接取config裡面的值  
```
hostName:TWN29664-24905, appDomain:名稱:NLogExample.exe
沒有內容原則。
, renderedLog:test debug, title:[DEBUG] on TWN29664-24905, Color:good,WebhookUrl:https://hooks.slack.com/services/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
```

------------------


NLog.config如下  
測試Target MyFirst裡面有設定contextproperty  
```
<extensions>
<add assembly="NLOG.Slack"/>
</extensions>

<targets>
<target name="first" xsi:type="MyFirst" includeEventProperties="true">
<contextproperty name="MachineName" layout="${machinename}" />
<contextproperty name="ThreadId" layout="${threadid}" />
</target>
<target
xsi:type="File"
name="f"
fileName="${basedir}/logs/${shortdate}.log"
layout="${longdate}|${level:uppercase=true}|${logger}|${message}" />
</targets>
<rules>
<logger name="*" minlevel="Debug" writeTo="f" />
<logger name="*" minlevel="Debug" writeTo="first" />
</rules>
```

由下例取得  
```
IDictionary<string, object> logProperties = this.GetAllProperties(logEvent);

String msg = $"hostName:{hostName}, message:{message} {Environment.NewLine}";
System.IO.File.AppendAllText(filepath, msg);

int i = 0;
foreach (var kvp in properties)
{
msg = $"[{i}] key:{kvp.Key} {Environment.NewLine}";
System.IO.File.AppendAllText(filepath, msg);
i++;
}
```

輸出log內容如下  
```
hostName:localhost, message:2022-05-10 15:00:57.3162|DEBUG|WatchdogServer|test debug
[0] key:MachineName
[1] key:ThreadId

```

--------


###  NLog/如何由程式加入NLog設定

```
        public static void Register(NlogEventTarget nlogEventTarget)
        {
            nlogEventTarget.Name = "event";
            nlogEventTarget.Layout = "${longdate} ${uppercase:${level}} ${message}";

            var config = LogManager.Configuration;
            config.AddTarget("nlogEvent", nlogEventTarget);
            var rule = new LoggingRule("*", LogLevel.Trace, nlogEventTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
            LogManager.Configuration.Reload();
        }
```

參考  
- [自製 NLog 的 Target（以 Slack 的 Incoming WebHooks 為例）][1]  
- [How to write a custom async target][2]  
- [How to write a custom layout renderer?][3]  
- [NLog 安装使用][4]  

[1]:https://dotblogs.com.tw/supershowwei/2020/06/22/112737
[2]:https://github.com/NLog/NLog/wiki/How-to-write-a-custom-async-target
[3]:https://nlog-project.org/2015/06/30/extending-nlog-is-easy.html
[4]:https://www.cnblogs.com/grayguo/p/5465106.html