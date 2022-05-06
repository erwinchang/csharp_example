# csharp_example

## InvokeRequired

[多執行緒中InvokeRequired和Invoke的用法，講的很清楚][1]


- C#中禁止跨執行緒直接訪問控制元件  
在Form1 UI中元件(label,textbox等)，只能在Form1主thread去設定  

- InvokeRequired是為了解決這個問題而產生的，當一個控制元件的InvokeRequired屬性值為真時  
說明有一個建立它以外的執行緒想訪問它  

- 此時它將會在內部呼叫new MethodInvoker(LoadGlobalImage)來完成下面的步驟  
這個做法保證了控制元件的安全  


```
        private void button1_Click(object sender, EventArgs e)
        {
            //m_comm_MessageEvent("TEST11");
            var thread = new Thread(Test);
            thread.Start();
        }
        private void Test()
        {
            m_comm_MessageEvent("TEST22");
        }        
        private void m_comm_MessageEvent(String msg)
        {
            //https://www.796t.com/content/1549952496.html
            Console.WriteLine($"InvokeRequired:{textBox1.InvokeRequired}");
            if (textBox1.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(m_comm_MessageEvent);
                textBox1.Invoke(msgCallback, new object[] { msg });
            }
            else            
            {
                //form1 thread InvokeRequired=0
                textBox1.Text = msg;
            }                
        }
```

測試結果如下

```
InvokeRequired:True
InvokeRequired:False
```
[1]:https://www.796t.com/content/1549952496.html