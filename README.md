# csharp_example

## NLOG

[使用「NLog」來記錄應用程式的大小事吧][1]

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

[1]:https://weitechshare.blogspot.com/2020/12/nlog.html