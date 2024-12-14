using System.Collections.Immutable;
using static System.Console;

namespace _2024_10_08___HW__Tasks_
{
    internal class Program
    {
        static void PrimeNumbers1()
        {
            for (int i = 0; i < 1000; i++)
                if (IsPrime(i))
                    WriteLine(i);
        }

        static void PrimeNumbers2(int start, int end)
        {
            for (int i = start; i < end; i++)
                if (IsPrime(i))
                    WriteLine(i);
        }

        static bool IsPrime(int num)
        {
            if (num == 0 || num == 1)
                return false;
            else
            {
                for (int a = 2; a <= num / 2; a++)
                    if (num % a == 0)
                        return false;
                return true;
            }
        }

        static void Main(string[] args)
        {
            /// 1
            //Task task1 = new Task(() => WriteLine($"Date 1 : {DateTime.Now.ToString()}"));
            //task1.Start();
            //
            //Task task2 = Task.Factory.StartNew(() => WriteLine($"Date 2 : {DateTime.Now.ToString()}"));
            //
            //Task task3 = Task.Run(() => WriteLine($"Date 3 : {DateTime.Now.ToString()}"));
            //
            //Task.WaitAll(task1, task2, task3);


            /// 2
            //Task task = new Task(PrimeNumbers1);
            //task.Start();
            //task.Wait();


            /// 3
            //(int start, int end) startend;
            //Write("Start : ");
            //startend.start = int.Parse(ReadLine());
            //Write("End : ");
            //startend.end = int.Parse(ReadLine());
            //if (startend.start > startend.end) startend = (startend.end, startend.start);
            //Task task = new Task(() => PrimeNumbers2(startend.start, startend.end));
            //task.Start();
            //task.Wait();


            /// 4
            //const int size = 20;
            //int[] array = new int[size];
            //Random rnd = new Random();
            //for (int i = 0; i < array.Length; i++)
            //    array[i] = rnd.Next(200) + 1;
            //WriteLine(string.Join(", ", array) + "\n");
            //Task<int>[] tasks = new Task<int>[]
            //{
            //    Task.Run(() => array.Min()),
            //    Task.Run(() => array.Max()),
            //    Task.Run(() => (int)array.Average()),
            //    Task.Run(() => array.Sum())
            //};
            //
            //Task.WaitAll(tasks);
            //
            //WriteLine($"Min: {tasks[0].Result}\n" +
            //          $"Max: {tasks[1].Result}\n" +
            //          $"Avg: {tasks[2].Result}\n" +
            //          $"Sum: {tasks[3].Result}");


            /// 5
            //const int size = 20;
            //int[] array = new int[size];
            //Random rnd = new Random();
            //for (int i = 0; i < array.Length; i++)
            //    array[i] = rnd.Next(20) + 1;
            //WriteLine(string.Join(", ", array) + "\n");
            //
            //int target;
            //do
            //{
            //    Clear();
            //    Write("Enter number (1-20) : ");
            //    target = int.Parse(ReadLine());
            //} while (target <= 0 || target > 20);
            //WriteLine();
            //
            //Task<int[]> distinctTask = Task.Run(() => array.Distinct().ToArray());
            //Task<int[]> sortTask = distinctTask.ContinueWith(prev => prev.Result.OrderBy(i => i).ToArray());
            //Task<int> searchTask = sortTask.ContinueWith(prev => Array.BinarySearch(prev.Result, target));
            //
            //Task.WaitAll(distinctTask, sortTask, searchTask);
            //
            //WriteLine("Distinct array: " + string.Join(", ", distinctTask.Result));
            //WriteLine("Sorted array: " + string.Join(", ", sortTask.Result));
            //WriteLine($"Index of {target}: {searchTask.Result}");
        }
    }
}
