/*
*
VLADIMIR RAEVSKY
HOMEWORK LESSON 4
TASK1

ЗАПОЛНЕНИЕ МАССИВА СЛУЧАЙНЫМИ ЧИСЛАМИ ОТ -10 000 ДО 10 000 / ВЫВОД КОЛИЧЕСТВА ПАР, КОТОРЫЕ ДЕЛЯТСЯ НА 3

*/
using System;


namespace homework4
{
    class IntArray
    {
        private int[] a;

        public IntArray(int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max);
        }
        public int CalcPairs
        {
            get
            {
                int previous = a[0];
                int count = 0;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i]!=0 && a[i-1]!=0 && a[i] % 3 == 0 && a[i-1] % 3 == 0)
                    { 
                        Console.WriteLine($"Result: {a[i - 1]} and {a[i]}");
                        count++;
                    }
                }
                return count;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (int b in a)
                s = s + b + " ";
            return s;
        }
    }

    class Task1
    {
        static void Main(string[] args)
        {
            IntArray a = new IntArray(20, -10000, 10000);
            Console.WriteLine("Array: [ " + a.ToString()+"]");
            Console.WriteLine("Number of positions: " + a.CalcPairs);
            Console.ReadKey();
        }
    }
}
