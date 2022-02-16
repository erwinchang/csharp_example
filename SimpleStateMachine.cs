using Appccelerate.StateMachine;
using Appccelerate.StateMachine.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class SimpleStateMachine
    {
        //https://github.com/appccelerate/statemachine
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
        //https://github.com/appccelerate/statemachine/blob/master/documentation/tutorial.md
        // Create either a passive or an active state machine, with support for async/await 
        private readonly PassiveStateMachine<States, Events> machine;

        public SimpleStateMachine()
        {

            //Use the one from the AsyncMachine namespace for state machines with support for async/await
            //or the one from the Machine namespace for state machines without async/await.
            var builder = new StateMachineDefinitionBuilder<States, Events>();

            builder
                .In(States.Off)
                .On(Events.TurnOn)
                .Goto(States.On)
                .Execute(SayHello);

            builder
                .In(States.On)
                .On(Events.TurnOff)
                .Goto(States.Off)
                .Execute(SayBye);

            //The state machine need to know in which state it should start.
            builder
                .WithInitialState(States.Off);

            machine = builder
                .Build()
                .CreatePassiveStateMachine();

            machine.Start();
        }
        public void TurnOn()
        {
            machine
                .Fire(
                    Events.TurnOn);
        }
        public void TurnOff()
        {
            machine
                .Fire(
                    Events.TurnOff);
        }

        private void SayHello()
        {
            Console.WriteLine("hello");
        }

        private void SayBye()
        {
            Console.WriteLine("bye");
        }
    }
}
