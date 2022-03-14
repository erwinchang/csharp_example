using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram2
    {
    }

    //https://zh.wikipedia.org/wiki/%E8%A7%82%E5%AF%9F%E8%80%85%E6%A8%A1%E5%BC%8F
    public interface IObserver
    {
        void Update(string message);
    }

    public class Subject
    {
        // use array list implementation for collection of observers
        private ArrayList observers;

        public Subject()
        {
            observers = new ArrayList();
        }

        public void Register(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }
        public void Deregister(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void Notify(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }
    }

    // Observer1 --> Implements the IObserver
    public class Observer1 : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine("Observer1:" + message);
        }
    }

    // Observer2 --> Implements the IObserver
    public class Observer2 : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine("Observer2:" + message);
        }
    }

    // Test class
    public class ObserverTester
    {
        public void Main()
        {
            Subject mySubject = new Subject();
            IObserver myObserver1 = new Observer1();
            IObserver myObserver2 = new Observer2();

            mySubject.Register(myObserver1);
            mySubject.Register(myObserver2);

            mySubject.Notify("message 1");
            mySubject.Notify("message 2");
        }
    }
}
