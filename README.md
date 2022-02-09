# csharp_example

## delegate
[C#委派delegate教學][1]

使用Delegate方式，在兩個Form之問傳送資料

```
form1
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.CallReceive += new Form2.EventReceive(seeText);
---------            
form2
    public partial class Form2 : Form
    {
        public delegate void EventReceive(string tmp);
        public EventReceive CallReceive;
```

<a href="https://imgur.com/teVGW6c"><img src="https://i.imgur.com/teVGW6c.gif" title="source: imgur.com" /></a>


[1]:https://lifewth.com/c_delegate/