# csharp_example

## Command Pattern

說明:  
Command Pattern將請求封裝成物件, 以便使用不同的請求、佇例(執行緒的計算工作)  
,日誌(記錄檢核點，可支援Rollback)，參數他其它物件  
Command Pattern也可以可支援Undo的作業  

情境:  
可以用來決定一群命令的執行的內容或順序

-------

## 範例

實現重點在於，分成發命令物件、命令物件、執行命令的物件。  
發命令物件：可用來新增要執行命令。  
命令物件：可指定執行此命令的物件。  
執行命令的物件：真正執行此命令的物件  

```
InvokerCommand invokerCmd = new InvokerCommand(2);   	// 發命令物件
BusinessCheckCommand bcc = new BusinessCheckCommand();	// 執行命令物件
IdentityChecksCommand identityChecks = new IdentityChecksCommand(bcc);   // 命令物件: id指令
DoCheckCommand doCheck = new DoCheckCommand(bcc);		 // 命令物件: check指令

invokerCmd.setCommand(0, identityChecks);               //設定要執行的命令
invokerCmd.setCommand(1, doCheck);

invokerCmd.runAllCommands();                           //執行命令
```          

```
    public interface iCommand
    {
        void execute();
xxx
    public class BusinessCheckCommand
    {
        public void IdentityChecks()
        public void DoCheck()     
xxx
    public class IdentityChecksCommand : iCommand
    {
        private BusinessCheckCommand businessCheckCommand;
        public void execute()
        {
            businessCheckCommand.IdentityChecks();
```  

[設計模式：命令模式 (Command Pattern)][1]

----------

## [Command Design Pattern Explained with C# Examples][2]

<a href="https://imgur.com/y4tdCrq"><img src="https://i.imgur.com/y4tdCrq.png" title="source: imgur.com" width="400px" /></a>


有5個部分

- 1.Command介面  
通過interface iCommand介面  
The Command declares an interface for the execution of an operation.  
(ex. iCommand)  

- 2.command實体  
內部有Receiver(即private businessCheckCommand)  
The ConcreteCommand defines a binding between a Receiver and an action.  
(ex.IdentityChecksCommand )  

- 3.Client  
即實現command實体，將Reciver帶入，這邊即為實現此範例的sub  

```
BusinessCheckCommand bcc = new BusinessCheckCommand();					 // 執行命令物件
IdentityChecksCommand identityChecks = new IdentityChecksCommand(bcc);   // 命令物件: id指令
```

The Client creates a ConcreteCommand object and sets a Receiver for the command.  

- 4.Invoker  
The Invoker demands the command carry out its request.  
(ex. InvokerCommand)  

- 5.Receiver  
The Receiver knows how to execute the operations associated with the action of the request.  
(ex. BusinessCheckCommand)  


[1]:https://xyz.cinc.biz/2013/07/command-pattern.html
[2]:https://www.syncfusion.com/blogs/post/command-design-pattern-tutorial-with-csharp-examples.aspx