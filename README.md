# csharp_example

## [Finite-State-Machine-FSM][1]

提供單純的狀態，沒有指令

1.先定議State
```
	public enum PlayerState
	{
		Idle,
		Run,
		Jump
	}
```

2.再設定transitions

```
(Idel ->Run ) : Run  //目前是Idel，要移到Run, 之後設定為Run
(Run  ->Jump) : Jump //目前是Run，要移到Jump, 之後設定為Jump

this.transitions = new Dictionary<StateTransition, PlayerState>
{
	{ new StateTransition(PlayerState.Idle, PlayerState.Run), PlayerState.Run }, //From Idle state to Run state 
	{ new StateTransition(PlayerState.Run, PlayerState.Jump), PlayerState.Jump },
};
```

3.用法
```
Console.WriteLine("## Current State = " + fsm.currentState);
Console.WriteLine("## Command.Begin: Current State = " + fsm.MoveNext(PlayerState.Run));
Console.WriteLine("## Invalid transition: " + fsm.CanReachNext(PlayerState.Idle));
Console.WriteLine("##　Previous State = " + fsm.previusState);
```

4.測試結果如下
```
BaseFSM
## Current State = Idle
Next state Run
Change state from Idle to Run
## Command.Begin: Current State = Run
Invalid transition: Run -> Idle
## Invalid transition: False
##　Previous State = Idle
```


[1]:https://github.com/MarcoMig/Finite-State-Machine-FSM