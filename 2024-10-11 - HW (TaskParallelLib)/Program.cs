using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2024_10_11___HW__TaskParallelLib_
{
    internal class Program
    {
        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            WriteLine("Factorial {0} : {1}", x, result);
        }

        static void SumaOfNumbers(int x)
        {
            char[] charDigits = x.ToString().ToCharArray();
            int res = 0;
            for (int i = 0; i < charDigits.Length; i++)
                res += (int)charDigits[i] - (int)'0';
            WriteLine("Suma Of Numbers : " + res);
        }

        public static void SerializeToFile(string filePath, int[] numbers)
        {
            var jsonString = JsonSerializer.Serialize(numbers);
            File.WriteAllText(filePath, jsonString);
        }

        public static int[] DeserializeFromFile(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<int[]>(jsonString);
        }

        static void Main(string[] args)
        {
            /// 1,2
            //Write("Enter number : ");
            //int num = int.Parse(ReadLine());
            //Parallel.Invoke(() => Factorial(num),
            //                () => WriteLine("Count Of Numbers : " + num.ToString().Length),
            //                () => SumaOfNumbers(num));


            /// 3
            //Write("Start : ");
            //int start = int.Parse(ReadLine());
            //Write("End : ");
            //int end = int.Parse(ReadLine());
            //Parallel.For(start, end + 1, i =>
            //{
            //    for (int j = 1; j <= 10; j++)
            //        WriteLine("{0} * {1} = {2}", i, j, i * j);
            //});


            /// 4
            //string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\numbers.txt";
            //const int size = 10;
            //int[] numbers = new int[size];
            //Random random = new Random();
            //for (int i = 0; i < size; i++)
            //    numbers[i] = random.Next(10) + 1;
            //SerializeToFile(path, numbers);
            //int[] numbers_ = DeserializeFromFile(path);
            //Parallel.ForEach(numbers_, Factorial);


            /// 5
            //string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\numbers.txt";
            //const int size = 10;
            //int[] numbers = new int[size];
            //Random random = new Random();
            //for (int i = 0; i < size; i++)
            //    numbers[i] = random.Next(1000) + 1;
            //SerializeToFile(path, numbers);
            //int[] numbers_ = DeserializeFromFile(path);
            //
            //var suma = numbers.AsParallel()
            //                  .Sum();
            //
            //var min = numbers.AsParallel()
            //                  .Min();
            //
            //var max = numbers.AsParallel()
            //                  .Max();
            //
            //WriteLine(string.Join(", ", numbers) + 
            //    "\nSuma : " + suma + 
            //    "\nMin : " + min + 
            //    "\nMax : " + max);
        }
    }
}
