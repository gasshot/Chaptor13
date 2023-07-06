using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChains
{
    delegate void Notify(string message);

    class Notifier
    {
        public Notify eventOccured;
    }

    class EventListener
    {
        private string name;

        public EventListener(string name)
        {
            this.name = name;
        }

        public void SomethingHappened(string message)
        {
            Console.WriteLine($"{name}.SomethingHappened : {message}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener eventListener1 = new EventListener("eventListener1");
            EventListener eventListener2 = new EventListener("eventListener2");
            EventListener eventListener3 = new EventListener("eventListener3");

            notifier.eventOccured += eventListener1.SomethingHappened;
            notifier.eventOccured += eventListener2.SomethingHappened;
            notifier.eventOccured += eventListener3.SomethingHappened;

            //notifier.eventOccured = new Notify(eventListener1.SomethingHappened)
            //    + new Notify(eventListener2.SomethingHappened)
            //    + new Notify(eventListener3.SomethingHappened);

            notifier.eventOccured("You`ve got mail.");
            Console.WriteLine();

            notifier.eventOccured -= eventListener3.SomethingHappened;
            notifier.eventOccured("Download Complete.");
            Console.WriteLine();

            notifier.eventOccured = new Notify(eventListener2.SomethingHappened)
                + new Notify(eventListener3.SomethingHappened);

            notifier.eventOccured("Nuclear launch Detected.");

            Console.WriteLine();

            Notify notify1 = new Notify(eventListener1.SomethingHappened);
            Notify notify2 = new Notify(eventListener2.SomethingHappened);

            notifier.eventOccured = (Notify)Delegate.Combine(notify1, notify2);
            notifier.eventOccured("Fire!!");

            Console.WriteLine();

            notifier.eventOccured = (Notify)Delegate.Remove(notifier.eventOccured, notify2);
            notifier.eventOccured("RPG!");
        }
    }
}
