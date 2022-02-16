# csharp_example

## [Simple state machine example in C#?][1]

We have:  
4 states (Inactive, Active, Paused, and Exited)  
5 types of state transitions (Begin Command, End Command, Pause Command, Resume Command, Exit Command).  

![Imgur](https://i.imgur.com/YZE2beg.png)


### 範例


```
Current State = Inactive
Command.Begin: Current State = Active
Command.Pause: Current State = Paused
Command.End: Current State = Inactive
Command.Exit: Current State = Terminated
```

[1]:https://stackoverflow.com/questions/5923767/simple-state-machine-example-in-c