# csharp_example

NLog.config
下例extensions是說是，會載入NLog.SlackTarget.dll
因為自訂的targets是Slack(會在NLog.SlackTarget.dll裡面)

```
  <extensions>
    <add assembly="NLog.SlackTarget"/>
  </extensions>

    <targets async="true">
    <target name="Slack" xsi:type="Slack"
```

### [NLog.SlackTarget][2]

[自製 NLog 的 Target（以 Slack 的 Incoming WebHooks 為例）][3]  

自訂NLogTarget需要
下例的[Target("Slack")]，是指採用NLog屬性
```
[Target("Slack")]
public class SlackTarget : AsyncTaskTarget
```

[TargetAttribute Class][4]


### [NLog Tutorial - The essential guide for logging from C#][1]


Log levels
- Fatal
- Error
- Warn
- Info
- Debug
- Trace

Log方式
```
log.Debug("This is a debug message");
log.Error(new Exception(), "This is an error message");
log.Fatal("This is a fatal message");
```

Log採用LogEventInfo Object方式  
```
var msg = new LogEventInfo(LogLevel.Info, "", "This is a message");
msg.Properties.Add("User", "Ray Donovan");
log.Info(msg);
```

If you are more a fluent kind of guy or gal, there's a great fluent API available too:  
```
logger
    .Info()
    .Message("This is a message")
    .Property("User", "Ray Donovan")
    .Write();
```

若想要將log訊息分類
```
log.Info(string.Format("This is a message from {0}", "Mickey Donovan"));
```

下例定議User，供Database查訊  
Notice the {User} property embedded in the log message? NLog will automatically format the string when generating the full log message, producing the same string as before.   
```
log.Info("This is a message from {User}", "Mickey Donovan");
```

Let's take a look at a simple config file:  
```
<?xml version="1.0" encoding="utf-8" ?>
<nlog
  xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <targets>
    <target
      xsi:type="Console"
      name="console"
      layout="${longdate}|${level:uppercase=true}|${logger}|${message}" />
  </targets>
  <rules>
    <logger name="*" minlevel="Debug" writeTo="console" />
  </rules>
</nlog>
```


[1]:https://blog.elmah.io/nlog-tutorial-the-essential-guide-for-logging-from-csharp/
[2]:https://github.com/supershowwei/NLog.SlackTarget
[3]:https://dotblogs.com.tw/supershowwei/2020/06/22/112737
[4]:https://nlog-project.org/documentation/v4.3.0/html/T_NLog_Targets_TargetAttribute.htm