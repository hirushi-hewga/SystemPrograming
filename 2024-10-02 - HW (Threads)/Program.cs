using System;
using System.Threading;
using static System.Console;

namespace _2024_10_02___HW__Threads_
{
    internal class Program
    {

        static void Method()
        {
            for (int i = 1; i <= 50; i++)
            {
                WriteLine(i);
                Thread.Sleep(50);
            }
        }

        static void Method2(object tuple)
        {
            ValueTuple<int, int>? t = tuple as ValueTuple<int, int>?;
            for (int i = t.Value.Item1; i <= t.Value.Item2; i++)
            {
                WriteLine(i);
                Thread.Sleep(50);
            }
        }

        static void Method3(object tuple)
        {
            ValueTuple<int, int>? t = tuple as ValueTuple<int, int>?;
            for (int i = t.Value.Item1; i <= t.Value.Item2; i++)
            {
                WriteLine(i);
                Thread.Sleep(50);
            }
        }

        static void Max(object arr)
        {
            int[] array = arr as int[];
            WriteLine($"Max : {array.Max()}");
        }

        static void Min(object arr)
        {
            int[] array = arr as int[];
            WriteLine($"Min : {array.Min()}");
        }

        static void Avg(object arr)
        {
            int[] array = arr as int[];
            WriteLine($"Avg : {array.Average()}");
        }

        static void Main(string[] args)
        {
            /// 1
            //Thread thread = new Thread(Method);
            //thread.Start();


            /// 2
            //Thread thread = new Thread(Method2);
            //int start;
            //int end;
            //do {
            //    try
            //    {
            //        thread = new Thread(Method2);
            //        Write("Start : ");
            //        start = int.Parse(ReadLine());
            //        Write("End : ");
            //        end = int.Parse(ReadLine());
            //        if (start <= end) thread.Start((start, end));
            //        else
            //        {
            //            Clear();
            //            ForegroundColor = ConsoleColor.Yellow;
            //            WriteLine("Start cannot be greater than End\n");
            //            ResetColor();
            //        }
            //        if (thread.IsAlive)
            //        {
            //            thread.Join();
            //            WriteLine("\nPress any key to continue...\n");
            //            ReadKey();
            //            Clear();
            //        }
            //    } catch (Exception ex)
            //    {
            //        Clear();
            //        ForegroundColor = ConsoleColor.Red;
            //        WriteLine(ex.Message + "\n");
            //        ResetColor();
            //    }
            //} while (true);


            /// 3
            //List<Thread> threads;
            //int numberOfThreads;
            //List<(int start, int end)> start_end;
            //int start;
            //int end;
            //do
            //{
            //    try
            //    {
            //        threads = new List<Thread>();
            //        start_end = new List<(int start, int end)>();
            //        numberOfThreads = 0;
            //
            //        do {
            //            Clear();
            //            Write("Enter number of threads : ");
            //            numberOfThreads = int.Parse(ReadLine());
            //        } while (numberOfThreads <= 0);
            //
            //        bool IsValidData;
            //        for (int i = 0; i < numberOfThreads; i++) {
            //            do {
            //                IsValidData = true;
            //                Write($"Thread {i + 1} Start : ");
            //                start = int.Parse(ReadLine());
            //                Write($"Thread {i + 1} End : ");
            //                end = int.Parse(ReadLine());
            //                if (start > end)
            //                {
            //                    Clear();
            //                    ForegroundColor = ConsoleColor.Yellow;
            //                    WriteLine("Start cannot be greater than End\n");
            //                    ResetColor();
            //                    IsValidData = false;
            //                }
            //                else start_end.Add((start, end));
            //            } while (!IsValidData);
            //        }
            //
            //        for (int i = 0; i < start_end.Count; i++)
            //        {
            //            threads.Add(new Thread(Method3));
            //            threads[i].Start(start_end[i]);
            //        }
            //
            //        bool isAllThreadsComple = false;
            //        while (!isAllThreadsComple)
            //        {
            //            isAllThreadsComple = true;
            //            foreach (var thread in threads)
            //            {
            //                if (thread.IsAlive)
            //                {
            //                    isAllThreadsComple = false;
            //                    break;
            //                }
            //            }
            //        }
            //        if (isAllThreadsComple)
            //        {
            //            WriteLine("\nPress any key to continue...\n");
            //            ReadKey();
            //            Clear();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Clear();
            //        ForegroundColor = ConsoleColor.Red;
            //        WriteLine(ex.Message + "\n");
            //        ResetColor();
            //    }
            //} while (true);


            ///4
            //const int size = 100;
            //int[] arr = new int[size];
            //Random r = new Random();
            //for (int i = 0; i < size; i++)
            //    arr[i] = r.Next(999) + 1;
            //for (int i = 0; i < size; i++)
            //{
            //    if (i % 20 - 1 == 0 && i != 1) WriteLine();
            //    Write($"{arr[i]} ");
            //}
            //WriteLine("\n");
            //
            //Thread max = new Thread(Max);
            //Thread min = new Thread(Min);
            //Thread avg = new Thread(Avg);
            //max.Start(arr);
            //min.Start(arr);
            //avg.Start(arr);


            ///5
            //string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/result.txt";
            //const int size = 100;
            //int[] arr = new int[size];
            //Random r = new Random();
            //for (int i = 0; i < size; i++)
            //    arr[i] = r.Next(999) + 1;
            //using (StreamWriter writer = new StreamWriter(path))
            //{
            //    for (int i = 0; i < size; i++)
            //    {
            //        if (i % 20 - 1 == 0 && i != 1)
            //        {
            //            WriteLine();
            //            writer.WriteLine();
            //        }
            //        Write($"{arr[i]} ");
            //        writer.Write($"{arr[i]} ");
            //    }
            //    writer.WriteLine("\n");
            //    WriteLine("\n");
            //}
            //
            //Thread max = new Thread(Max);
            //Thread min = new Thread(Min);
            //Thread avg = new Thread(Avg);
            //max.Start(arr);
            //min.Start(arr);
            //avg.Start(arr);
            //
            //File.AppendAllText(path, $"Min : {arr.Min()}\nMax : {arr.Max()}\nAvg : {arr.Average()}\n");
        }
    }
}
