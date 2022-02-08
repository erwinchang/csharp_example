# csharp_example

## 1 NLOG範例

[使用「NLog」來記錄應用程式的大小事吧][3]

### 1-1 安裝package

![Imgur](https://i.imgur.com/hnBF3tc.png)


### 1-2 測試如下

```
        private void Form1_Load(object sender, EventArgs e)
        {
            var log = LogManager.GetCurrentClassLogger();
            log.Info($"Test");
        }
```        

NLog.config修正如下
```
  <targets>
	  <target xsi:type="File" name="f" fileName="${basedir}/logs/${shortdate}.log"
			  layout="${longdate} ${uppercase:${level}} ${message}" />
  </targets>
  <rules>
      	  <logger name="*" minlevel="Debug" writeTo="f" />
  </rules>
```

測試結果如下

![Imgur](https://i.imgur.com/LUxkX5G.png)

2022-02-08.log
```
2022-02-08 15:16:37.5479 INFO Test
```

--------------

## 2 NLOG說明

[Tutorial][1]
[Configuration file][2]

### 2-1 Log Levels

| ID |Level | Typical Use |
|:----|:-----|:------------|
| 5 | Fatal | Something bad happened; application is going down |
| 4 | Error | Something failed; application may or may not continue |
| 3 | Warn  | Something unexpected; application will continue |
| 2 | Info  | Normal behavior like mail sent, user updated profile etc. |
| 1 | Debug | For debugging; executed query, user authenticated, session expired |
| 0 | Trace | For trace debugging; begin method X, end method X |


若minlevel設定Debug，則Trace不會被寫入檔案


------------

### 2-2 Best practices for using NLog

1. Logger should be a static variable in each class

```
namespace MyNamespace
{
  public class MyClass
  {
    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
  }
}
```

2. Logger should handle string formatting
即不要在Logger裡面字串採用```$```等動態變數

若要採用變數，採用下例方式
```
            logger.Fatal("Hello {0}", "Fatal");
            logger.Error("Hello {0}", "Error");
            logger.Warn("Hello {0}", "Warn");
            logger.Info("Hello {0}", "Info");
            logger.Debug("Hello {0}", "Debug");
            logger.Trace("Hello {0}", "Trace");
```

3. Logger should be given the Exception

Avoid giving the Exception as formatting parameter, but instead provide it explicitly as first parameter.
自已處理Exception字串內容如下

```
try
{
}
catch (Exception ex)
{
    logger.Error(ex, "Something bad happened");
}
```

5. Remember to Flush

NLog will by default attempt to flush automatically at application shutdown.

```
NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
```

---------


### 2-3 config說明

將Debug導到logfile(即file.txt)
將Info導到logconsole(即Console)

```
    <targets>
        <target name="logfile" xsi:type="File" fileName="file.txt" />
        <target name="logconsole" xsi:type="Console" />
    </targets>
    <rules>
        <logger name="*" minlevel="Info" writeTo="logconsole" />
        <logger name="*" minlevel="Debug" writeTo="logfile" />
    </rules>
```

------


### 2-4 範例1

若minlevel設定Debug，則Trace不會被寫入檔案

```
<targets>
    <target xsi:type="File" name="f" fileName="${basedir}/logs/${shortdate}.log"
        layout="${longdate} ${uppercase:${level}} ${message}" />
</targets>
<rules>
<logger name="*" minlevel="Debug" writeTo="f" />
</rules>
```


2022-02-08.log
```
2022-02-08 15:39:25.6846 FATAL Test: Fatal
2022-02-08 15:39:25.7066 ERROR Test: Error
2022-02-08 15:39:25.7066 WARN Test: Warn
2022-02-08 15:39:25.7066 INFO Test: Info
2022-02-08 15:39:25.7066 DEBUG Test: Debug
```

---------

### 2-5 範例2

log檔案會被寫入(Fatal,Error,Warn,Info,Debug)，因為最小設定Debug
console同時會輸出(Fatal,Error,Warn,Info)，因為最小設定Info


```
    <target xsi:type="File" name="f" fileName="${basedir}/logs/${shortdate}.log"
        layout="${longdate} ${uppercase:${level}} ${message}" />
    <target name="logconsole" xsi:type="Console" />

    <logger name="*" minlevel="Info" writeTo="logconsole" />
    <logger name="*" minlevel="Debug" writeTo="f" />    
```


console如下
```
2022-02-08 15:43:32.8924|FATAL|csharp_example.Form1|Test: Fatal
2022-02-08 15:43:32.9153|ERROR|csharp_example.Form1|Test: Error
2022-02-08 15:43:32.9153|WARN|csharp_example.Form1|Test: Warn
2022-02-08 15:43:32.9153|INFO|csharp_example.Form1|Test: Info
```

2022-02-08.log
```
2022-02-08 15:43:32.8924 FATAL Test: Fatal
2022-02-08 15:43:32.9153 ERROR Test: Error
2022-02-08 15:43:32.9153 WARN Test: Warn
2022-02-08 15:43:32.9153 INFO Test: Info
2022-02-08 15:43:32.9153 DEBUG Test: Debug
```

-------

### 2-6 範例3

Logger在處理Exceiption，一定要加入，字串不然會出錯如下

```
            try
            {
                Logger.Info("Hello World");
                System.Console.ReadKey();
            }catch(Exception ex)
            {
                Logger.Error(ex.ToString());
            }

於 System.InvalidOperationException 擲回例外狀況: 'mscorlib.dll'            
```

採用方式如下，自訂錯誤字串
```
            try
            {
                Logger.Info("Hello World");
                System.Console.ReadKey();
            }catch(Exception ex)
            {
                Logger.Error(ex,"Goodbye cruel world");
            }
```            

[1]:https://github.com/NLog/NLog/wiki/Tutorial
[2]:https://github.com/NLog/NLog/wiki/Configuration-file#log-levels

[3]:https://weitechshare.blogspot.com/2020/12/nlog.html