using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram
    {
    }

    public interface iSubject
    {
        void Attach(iObserver observer);
        void Detach(iObserver ovserver);
        void Notify();
    }

    class ConcreteSubject : iSubject
    {
        private string subjectState;
        private bool changed;
        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }

        private System.Collections.ArrayList observers = new System.Collections.ArrayList();

        public void Attach(iObserver observer)
        {
            observers.Add(observer);
            if(observers.Count >= 1)
            {
                this.changed = true;
            }
            else
            {
                this.changed = false;
            }
        }

        public void Detach(iObserver observer)
        {
            observers.Remove(observer);
            if(observers.Count >= 1)
            {
                this.changed = true;
            }
            else
            {
                this.changed = false;
            }
        }

        public void Notify()
        {
            if(changed == true)
            {
                foreach(iObserver o in observers)
                {
                    o.Update();
                }
            }
            this.changed = false;
        }
    }

    public interface iObserver
    {
        void Update();
    }
    class ConcreteObserver : iObserver
    {
        private string User;
        private string observerState;
        private ConcreteSubject subject;

        public ConcreteObserver(ConcreteSubject subject,string user)
        {
            this.subject = subject;
            this.User = user;
        }

        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine($"User:{User},observerState:{observerState}");
        }
    }
}
