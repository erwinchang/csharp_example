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
    public interface iComponet
    {
        void operation();
    }
    class ConcreteComponet : iComponet
    {
        public void operation()
        {
            MessageBox.Show("Check file format:","ConcreteComponet");
        }
    }
    public abstract class Decorator : iComponet
    {
        private iComponet componet;
        public Decorator()
        {
            this.componet = null;
        }
        public Decorator(iComponet componet)
        {
            this.componet = componet;
        }
        public virtual void operation()
        {
            if(componet != null)
            {
                componet.operation();
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA()
        {

        }
        public ConcreteDecoratorA(iComponet icompoent) : base(icompoent)
        {

        }
        private string ProcessStatus { get; set; }
        public override void operation()
        {
            base.operation();
            ProcessStatus = "Sucessfully";
            MessageBox.Show("Process files " + ProcessStatus, "ConcreteDecoratorA");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(iComponet icompoent) : base(icompoent)
        {

        }
        private string ProcessStatus { get; set; }
        public override void operation()
        {
            base.operation();
            CheckFieldValue();
            MessageBox.Show("File's contents is correct!!", "ConcreteDecoratorB");
        }
        void CheckFieldValue()
        {
            MessageBox.Show("Check the file contents of the field values.", "ConcreteDecoratorB");
        }
    }
}
