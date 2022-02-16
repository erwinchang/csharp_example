# csharp_example

## State Machine

### [Appccelerate.StateMachine][1]


- 1.建立StateMachine

```
    private enum States
    {
        On,
        Off
    }

    private enum Events
    {
        TurnOn,
        TurnOff
    }

//Create either a passive or an active state machine, with support for async/await or without:    
PassiveStateMachine<States, Events> machine;
ActiveStateMachine() // create an active state machine
```

- 2.建立build串起動作

We use the StateMachineDefinitionBuilder to define our state machine.

- 2.1 A simple transition

```
builder.In(States.A)
   .On(Events.B).Goto(States.B);
```
If the state machine is in state A and receives event B then it performs a transition to state B.


- 2.2 Transition with action

```
builder.In(States.A)
    .On(Events.B)
        .Goto(States.B)
        .Execute(() => { /* do something here */ });
```

-2.3 Fire Events
To get the state machine to do its work, you send events to it:
通過.Fire來執行machine裡面Event

```
    public void TurnOff()
    {
        machine
            .Fire(
                Events.TurnOff);
    }
```


### 來源

[Tutorial][2]  
[Example][3]  


### 測式

測試如下
```
SS:csharp_example.SimpleStateMachine
hello
SS:csharp_example.SimpleStateMachine
bye
SS:csharp_example.SimpleStateMachine
```

[1]:https://www.nuget.org/packages/Appccelerate.StateMachine/
[2]:https://github.com/appccelerate/statemachine/blob/master/documentation/tutorial.md
[3]:https://github.com/appccelerate/statemachine/blob/master/documentation/example.md
