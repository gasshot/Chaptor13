﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    delegate void EventHandler(string message);

    class MyNotifier
    {
        public event EventHandler SomethingHappened;

        public void DoSomething(int number)
        {
            int temp = number % 10;

            if (temp != 0 && temp % 3 == 0)
            {
                SomethingHappened(string.Format("{0} : 짝", number));
            }
        }
    }

    class MainApp
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            MyNotifier myNotifier = new MyNotifier();

            myNotifier.SomethingHappened += new EventHandler(MyHandler);

            for (int i = 1; i < 30; i++)
            {
                myNotifier.DoSomething(i);
            }
        }

    }
}
