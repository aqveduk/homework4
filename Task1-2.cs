/*
*
VLADIMIR RAEVSKY
HOMEWORK LESSON 4
TASK1-2

ЗАПОЛНЕНИЕ МАССИВА СЛУЧАЙНЫМИ ЧИСЛАМИ ОТ -10 000 ДО 10 000 / ВЫВОД ПАР, КОТОРЫЕ ДЕЛЯТСЯ НА 3

*/
using System;
using System.IO;

namespace homework4
{
    /// <summary>
    /// Create arrays and methods to process them
    /// </summary>
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
        /// <summary>
        /// Read array data from text file
        /// </summary>
        /// <param name="filename"></param>
        public IntArray(string filename)
        {
            StreamReader sr = new StreamReader("..\\..\\data.txt");
            int N = int.Parse(sr.ReadLine());
            a = new int[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = int.Parse(sr.ReadLine());
            }
            sr.Close();
        }

        public void WriteToFileProp(int num)
        {
            string myString = num.ToString();
            File.WriteAllText(@"..\..\data2.txt", myString);
            Console.WriteLine("File has been succesfully updated");
        }

        /// <summary>
        /// Show all pairs from array which are divisible to 3 
        /// </summary>
        public int CalcPairs
        {
            get
            {
                int previous = a[0];
                int count = 0;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] % 3 == 0 && a[i - 1] % 3 == 0)
                    {
                        Console.WriteLine($"Result: {a[i - 1]} and {a[i]}");
                        count++;
                    }
                }
                return count;
            }
        }
        /// <summary>
        /// Sum all elements
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int elem in a)
                    sum += elem;
                return sum;
            }
        }

        /// <summary>
        /// Multiplication of elemtis in array
        /// </summary>
        public int[] Multi(int n)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= 5;
            }
            return a;
        }
        /// <summary>
        /// Inverse all elements in array
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= -1;
            }
            return a;
        }
        /// <summary>
        /// Return elements of array
        /// </summary>
        /// <returns></returns>
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
            IntArray a = new IntArray(5, -10, 10);
            Console.WriteLine("Array: [ " + a.ToString() + "]");
            Console.WriteLine("Number of positions: " + a.CalcPairs);
            Console.WriteLine("Sum of elements: " + a.Sum);
            a.Multi(5);
            Console.WriteLine("Multiplication of elements: " + a.ToString());
            a.Inverse();
            Console.WriteLine("Inverse elements: " + a.ToString());

            IntArray b = new IntArray("data2.txt");
            b.WriteToFileProp(b.Sum);
            Console.WriteLine("Array: [ " + b.ToString() + "]");


            Console.ReadKey();
        }
    }
}
