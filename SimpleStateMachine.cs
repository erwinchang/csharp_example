using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
	//https://github.com/MarcoMig/Finite-State-Machine-FSM/blob/master/FSM/ChildFSM.cs
	public enum PlayerState
	{
		Idle,
		Run,
		Jump
	}

	class SimpleStateMachine : BaseFSM<PlayerState>
	{
		public void ChildFSM()
        {
			this.currentState = PlayerState.Idle;
			this.transitions = new Dictionary<StateTransition, PlayerState>
			{
				{ new StateTransition(PlayerState.Idle, PlayerState.Run), PlayerState.Run }, //From Idle state to Run state 
				{ new StateTransition(PlayerState.Run, PlayerState.Jump), PlayerState.Jump },
			};
		}

	}
}
