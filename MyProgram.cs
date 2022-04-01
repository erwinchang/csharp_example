using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    class MyProgram
    {
    }
    public class Example
    {
        public void Main()
        {
            Console.WriteLine("Example Main");
        }
    }

    public interface iCommand
    {
        void execute();
        //void undo();
        //void save();
        //void load();
    }
    public class BusinessCheckCommand
    {
        public void IdentityChecks()
        {
            MessageBox.Show("身分查核!!","IdentityChecks()");
        }
        public void DoCheck()
        {
            MessageBox.Show("行李檢查!!", "DoCheck()");
            MessageBox.Show("護照檢查!!", "DoCheck()");
        }
    }
    public class IdentityChecksCommand : iCommand
    {
        private BusinessCheckCommand businessCheckCommand;
        public IdentityChecksCommand(BusinessCheckCommand bcc)
        {
            this.businessCheckCommand = bcc;
        }
        public void execute()
        {
            businessCheckCommand.IdentityChecks();
        }
    }
    public class DoCheckCommand : iCommand
    {
        private BusinessCheckCommand businessCheckCommand;
        public DoCheckCommand(BusinessCheckCommand bcc)
        {
            this.businessCheckCommand = bcc;
        }
        public void execute()
        {
            businessCheckCommand.DoCheck();
        }
    }
    public class NoCommand : iCommand
    {
        public void execute()
        {
            MessageBox.Show("Nothing to do.", "NoCommand");
        }
    }
    public class InvokerCommand
    {
        private iCommand[] commands;
        public InvokerCommand()
        {
            commands = new iCommand[1];
            commands[0] = new NoCommand();
        }
        public InvokerCommand(int num)
        {
            commands = new iCommand[num];
            for(int i=0; i< commands.Length; i++)
            {
                commands[i] = new NoCommand();
            }
        }
        public void setCommand(int slot,iCommand cmd)
        {
            commands[slot] = cmd;
        }
        public void runCommand(int slot)
        {
            commands[slot].execute();
        }
        public void runAllCommands()
        {
            for(int i =0; i<commands.Length; i++)
            {
                commands[i].execute();
            }
        }
    }
}
