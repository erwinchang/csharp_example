# csharp_example


### Delegate

1.Thread無法存取UI問題，如下

<a href="https://imgur.com/gNroYlO"><img src="https://i.imgur.com/gNroYlO.png" title="source: imgur.com" width="400px" /></a>

[Control.InvokeRequired 屬性][2]  
取得一個值。這個值會指示是否由於呼叫端是在建立控制項之執行緒以外的執行緒  


[多執行緒中InvokeRequired和Invoke的用法，講的很清楚][3]
- C#中禁止跨執行緒直接訪問控制元件
- InvokeRequired是為了解決這個問題而產生的
- 當一個控制元件的InvokeRequired屬性值為真時，說明有一個建立它以外的執行緒想訪問它
- 此時它將會在內部呼叫new MethodInvoker(LoadGlobalImage)來完成下面的步驟
- 這個做法保證了控制元件的安全

你可以這樣理解，有人想找你借錢，他可以直接在你的錢包中拿，這樣太不安全，因此必須讓別人先要告訴你，你再從自己的錢包把錢拿出來借給別人，這樣就安全了


### This.Invoke

[C# this.Invoke()的作用與用法][4]

Invoke()的作用是：在應用程序的主線程上執行指定的委托
一般應用：在輔助線程中修改UI線程（ 主線程 ）中對象的屬性時，調用this.Invoke();

在多線程編程中，我們經常要在工作線程中去更新界面顯示，而**在多線程中直接調用界面控件的方法是錯誤的做法**
Invoke 和 BeginInvoke 就是為了解決這個問題而出現的，使你在多線程中安全的更新界面顯示

正確的做法是將工作線程中涉及更新界面的代碼封裝為一個方法，通過 Invoke 或者 BeginInvoke 去調用，兩者的區別就是一個導致工作線程等待，而另外一個則不會

### Thread

[Thread 類別][1]
可建立和控制執行緒，設定執行緒的優先權，並取得它的狀態。
Join: 會等待thread結束才會往下執行

```
Main thread: Start a second thread.
Main thread: Do some work.
Main thread: Do some work.
Main thread: Do some work.
Main thread: Do some work.
Main thread: Call Join(), to wait until ThreadProc ends.
ThreadProc: 0
ThreadProc: 1
ThreadProc: 2
ThreadProc: 3
ThreadProc: 4
ThreadProc: 5
ThreadProc: 6
ThreadProc: 7
ThreadProc: 8
```

-----------------

[Control.Invoke 方法][5]

在擁有控制項基礎視窗控制代碼的執行緒上執行委派

方式如下
Invoke(Delegate) 在擁有控制項基礎視窗控制代碼的執行緒上執行指定的委派  
Invoke(Delegate, Object[]) 在擁有控制項基礎視窗控制代碼的執行緒上，以指定的引數清單執行指定的委派  

```
public delegate void AddListItem(String myString);   //宣告 委派 函數 AddListItem
public AddListItem myDelegate;                       //定義 委派函數(AddListItem) 變數

public Form1(){
	InitializeComponent();
	myDelegate = new AddListItem(AddListItemMethod); //指定 委派函數 callback function AddListItemMethod
}
public void AddListItemMethod(String myString){
	listBox1.Items.Add(myString);                    //由callback function設定form1 UI，確保在多個thread下安全機制更改
}
```

```
public class MyThreadClass{
	public void Run()
	{
		myform1.Invoke(myform1.myDelegate, new Object[] { myString });  //採用Invoke呼叫Delegate，來更改UI內容
	}
}
```

<a href="https://imgur.com/I8dFiOC"><img src="https://i.imgur.com/I8dFiOC.png" title="source: imgur.com" width="400px" /></a>


[1]:https://docs.microsoft.com/zh-tw/dotnet/api/system.threading.thread?view=net-6.0
[2]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.control.invokerequired?view=windowsdesktop-6.0
[3]:https://www.796t.com/content/1549952496.html
[4]:http://www.aspphp.online/bianchen/dnet/gydnet/201701/169881.html
[5]:https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.control.invoke?view=windowsdesktop-6.0&viewFallbackFrom=netstandard-2.0