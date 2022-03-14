using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram4
    {
    }

    //https://docs.microsoft.com/zh-tw/dotnet/standard/events/observer-design-pattern
    //BaggageInfo 類別提供有關抵達班機及可提領各班機行李之轉盤的資訊

    public class BaggageInfo
    {
        private int flightNo;
        private string origin;
        private int location;

        //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/internal
        //internal 內部類型或成員只能在相同組件的檔案內存取
        internal BaggageInfo(int flight, string from, int carousel)
        {
            this.flightNo = flight;
            this.origin = from;
            this.location = carousel;
        }
        public int FlightNumber
        {
            get { return this.flightNo; }
        }
        public string From
        {
            get { return this.origin; }
        }
        public int Carousel
        {
            get { return this.location; }
        }
    }

    //BaggageHandler 負責接收有關抵達班機和行李提領轉盤的資訊。 它在內部維護兩個集合
    //observers - 將接收更新資訊的用戶端集合
    //flights - 班機及其指派轉盤的集合

    //提供者是實作 IObservable<T> 介面的類別或結構
    //提供者必須實作單一方法 IObservable<T>.Subscribe
    //IDisposable 實作，可讓提供者在通知完成時移除觀察者。 觀察者會從 Subscribe 方法接收
    public class BaggageHandler : IObservable<BaggageInfo>
    {
        private List<IObserver<BaggageInfo>> observers;
        private List<BaggageInfo> flights;

        public BaggageHandler()
        {
            observers = new List<IObserver<BaggageInfo>>();
            flights = new List<BaggageInfo>();
        }
        public IDisposable Subscribe(IObserver<BaggageInfo> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                // Provide observer with existing data.
                foreach (var item in flights)
                    observer.OnNext(item);
            }
            return new Unsubscriber<BaggageInfo>(observers, observer);
        }

        // Called to indicate all baggage is now unloaded.
        //在第二個案例中，只會對方法傳遞一個班機號碼。 針對正在卸載的行李
        public void BaggageStatus(int flightNo)
        {
            BaggageStatus(flightNo, String.Empty, 0);
        }

        //呼叫多載的 BaggageHandler.BaggageStatus 方法，以指出班機的行李正在卸載，或是已卸載完成
        //在第一個案例中，會對方法傳遞一個班機號碼、班機的起飛機場，以及卸載行李的轉盤
        public void BaggageStatus(int flightNo, string from, int carousel)
        {
            var info = new BaggageInfo(flightNo, from, carousel);

            // Carousel is assigned, so add new info object to list.
            if (carousel > 0 && !flights.Contains(info))
            {
                flights.Add(info);
                foreach (var observer in observers)
                    observer.OnNext(info);
            }
            else if (carousel == 0)
            {
                // Baggage claim for flight is done
                var flightsToRemove = new List<BaggageInfo>();
                foreach (var flight in flights)
                {
                    if (info.FlightNumber == flight.FlightNumber)
                    {
                        flightsToRemove.Add(flight);
                        foreach (var observer in observers)
                            observer.OnNext(info);
                    }
                }
                foreach (var flightToRemove in flightsToRemove)
                {
                    flights.Remove(flightToRemove);
                }
                flightsToRemove.Clear();
            }
        }
        public void LastBaggageClaimed()
        {
            foreach (var observer in observers)
                observer.OnCompleted();

            observers.Clear();
        }
    }
    internal class Unsubscriber<BaggageInfo> : IDisposable
    {
        private List<IObserver<BaggageInfo>> _observers;
        private IObserver<BaggageInfo> _observer;

        internal Unsubscriber(List<IObserver<BaggageInfo>> observers, IObserver<BaggageInfo> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }
        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }

    //觀察者必須實作三種方法，這三種方法全都是由提供者呼叫
    //IObserver<T>.OnNext，提供新的或目前的資訊給觀察者
    //IObserver<T>.OnError，通知觀察者發生錯誤
    //IObserver<T>.OnCompleted，指出提供者已完成傳送通知
    public class ArrivalsMonitor : IObserver<BaggageInfo>
    {
        private string name;
        private List<string> flightInfos = new List<string>();
        private IDisposable cancellation;
        private string fmt = "{0,-20} {1,5}  {2, 3}";

        public ArrivalsMonitor(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("The observer must be assigned a name.");

            this.name = name;
        }

        public virtual void Subscribe(BaggageHandler provider)
        {
            cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            flightInfos.Clear();
        }
        public virtual void OnCompleted()
        {
            flightInfos.Clear();
        }
        public virtual void OnNext(BaggageInfo info)
        {
            bool updated = false;

            // Flight has unloaded its baggage; remove from the monitor.
            if (info.Carousel == 0)
            {
                var flightsToRemove = new List<string>();
                string flightNo = String.Format("{0,5}", info.FlightNumber);
                foreach (var flightInfo in flightInfos)
                {
                    if (flightInfo.Substring(21, 5).Equals(flightNo))
                    {
                        flightsToRemove.Add(flightInfo);
                        updated = true;
                    }
                }

                foreach (var flightToRemove in flightsToRemove)
                    flightInfos.Remove(flightToRemove);
            }
            else
            {
                // Add flight if it does not exist in the collection.
                string flightInfo = String.Format(fmt, info.From, info.FlightNumber, info.Carousel);
                if (!flightInfos.Contains(flightInfo))
                {
                    flightInfos.Add(flightInfo);
                    updated = true;
                }
            }
            if (updated)
            {
                flightInfos.Sort();
                Console.WriteLine("Arrivals information from {0}", this.name);
                foreach (var flightInfo in flightInfos)
                    Console.WriteLine(flightInfo);

                Console.WriteLine();
            }
        }
        public virtual void OnError(Exception e)
        {

        }
    }

    public class Example
    {
        public  void Main()
        {
            BaggageHandler provider = new BaggageHandler();
            ArrivalsMonitor observer1 = new ArrivalsMonitor("BaggageClaimMonitor1");
            ArrivalsMonitor observer2 = new ArrivalsMonitor("SecurityExit");

            provider.BaggageStatus(712, "Detroit", 3);
            observer1.Subscribe(provider);
            provider.BaggageStatus(712, "Kalamazoo", 3);
            provider.BaggageStatus(400, "New York-Kennedy", 1);
            provider.BaggageStatus(712, "Detroit", 3);
            observer2.Subscribe(provider);
            provider.BaggageStatus(511, "San Francisco", 2);
            provider.BaggageStatus(712);
            observer2.Unsubscribe();
            provider.BaggageStatus(400);
            provider.LastBaggageClaimed();
        }
    }
}
