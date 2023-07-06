using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    delegate int Compare<T>(T a, T b);
    


    class MainApp
    {
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return - 1 * a.CompareTo(b);
        }

        static void BubbleSort<T>(T[] dataset, Compare<T> comparer)
        {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 0; i < dataset.Length - 1; i++)
            {
                for (j = 0; j < dataset.Length - (i + 1); j++)
                {
                    if (comparer(dataset[j], dataset[j + 1]) > 0)
                    {
                        temp = dataset[j + 1];
                        dataset[j + 1] = dataset[j];
                        dataset[j] = temp;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending...");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            //Console.WriteLine();

            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };

            Console.WriteLine("\nSorting descending...");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]} ");
            }

            Console.WriteLine();


        }
    }
}
