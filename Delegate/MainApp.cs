using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Calculator cal = new Calculator();
            MyDelegate myDelegate;

            myDelegate = new MyDelegate(cal.Plus);
            Console.WriteLine(myDelegate(3, 4));

            myDelegate = new MyDelegate(cal.Minus);
            Console.WriteLine(myDelegate(7, 5));

        }
    }
}
