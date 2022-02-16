﻿using System;
using System.Collections.Generic;

//https://github.com/MarcoMig/Finite-State-Machine-FSM/blob/master/FSM/BaseFSM.cs
public class BaseFSM<T> where T : struct, IConvertible
{
	#region State Transition
	//Basic class that denote the transition between one state and another
	public class StateTransition
	{
		public T currentState { get; set; }
		public T nextState { get; set; }

		//StateTransition Constructor
		public StateTransition(T currentState, T nextState)
		{
			this.currentState = currentState;
			this.nextState = nextState;
		}

		public override int GetHashCode()
		{
			return 17 + 31 * this.currentState.GetHashCode() + 31 * this.nextState.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			StateTransition other = obj as StateTransition;
			return other != null && this.currentState.Equals(other.currentState) && this.nextState.Equals(other.nextState);
		}
	}
	#endregion

	#region BaseFsm Implementation
	protected Dictionary<StateTransition, T> transitions; //Will contain all the transitions inside the FSM
	public T currentState;
	public T previusState;

	protected BaseFSM()
	{
		// Throw Exception on static initialization if the given type isn't an enum.
		if (!typeof(T).IsEnum)
			throw new Exception(typeof(T).FullName + " is not an enum type.");
	}

	private T GetNext(T next)
	{
		StateTransition transition = new StateTransition(currentState, next);
		T nextState;
		if (!transitions.TryGetValue(transition, out nextState))
			throw new Exception("Invalid transition: " + currentState + " -> " + next);
		Console.WriteLine("Next state " + nextState);
		return nextState;
	}

	//Used to check if the next state is reachable
	public bool CanReachNext(T next)
	{
		StateTransition transition = new StateTransition(currentState, next);
		T nextState;
		if (!transitions.TryGetValue(transition, out nextState))
		{
			Console.WriteLine("Invalid transition: " + currentState + " -> " + next);
			return false;
		}
		else
		{
			return true;
		}
	}

	public T MoveNext(T next)
	{
		previusState = currentState;
		currentState = GetNext(next);
		Console.WriteLine("Change state from " + previusState + " to " + currentState);
		return currentState;
	}
	#endregion
}