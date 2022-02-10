# csharp_example

## NLog / RichTextBox-target

[RichTextBoxTarget Class][1]

```
    <targets>
 6        <target name="richTextBox" xsi:type="RichTextBox" controlName="richTextBox1" formName="form1" useDefaultRowColoringRules="false"/>
 7    </targets>
 8
 9    <rules>
10        <logger name="*" minlevel="Debug" writeTo="richTextBox" />
11    </rules>
```

```
16        private void Form1_Load(object sender, EventArgs e)
17        {
18
19            RichTextBoxTarget target = new RichTextBoxTarget();
20            target.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";
21            target.ControlName = "richTextBox1";
22            target.FormName = "Form1";
23            target.UseDefaultRowColoringRules = true;
24
25            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Trace);
26
27            Logger logger = LogManager.GetLogger("Example");
28            logger.Trace("trace log message");
29            logger.Debug("debug log message");
30            logger.Info("info log message");
31            logger.Warn("warn log message");
32            logger.Error("error log message");
33            logger.Fatal("fatal log message");
34        }
```

### 測試如下

<a href="https://imgur.com/f6bysYu"><img src="https://i.imgur.com/f6bysYu.png" title="source: imgur.com" style="width:200px;" /></a>

### 其它參考

- [NLog.Windows.Forms][2]

- [RichTextBoxTarget][3]
Log text a Rich Text Box control in an existing or new form.
Supported in .NET, .NET Core 3.1 and .NET 5 - Windows only

- [RichTextBoxTarget Class][4]

- [NLog.Windows.Forms 4.5.0-rc.1][5]
.NETFramework 3.5

```
.NETCoreApp 3.1
NLog (>= 4.7.9)
.NETFramework 3.5
NLog (>= 4.7.9)
net5.0-windows7.0
NLog (>= 4.7.9)
```


[1]:https://nlog-project.org/documentation/v2.0.1/html/T_NLog_Targets_RichTextBoxTarget.htm
[2]:https://github.com/NLog/NLog.Windows.Forms
[3]:https://github.com/NLog/NLog.Windows.Forms/wiki/RichTextBoxTarget
[4]:https://nlog-project.org/documentation/v4.5.0/html/T_NLog_Windows_Forms_RichTextBoxTarget.htm
[5]:https://www.nuget.org/packages/NLog.Windows.Forms/4.5.0-rc.1