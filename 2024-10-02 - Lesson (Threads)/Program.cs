using static System.Console;

namespace _2024_10_02___Lesson__Threads_
{
    class Program
    {
        static void Method()
        {
            for (int i = 0; i < 100; i++)
            {
                WriteLine($"\t\t\t{i} - Hello in thread");
                Thread.Sleep(50);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
