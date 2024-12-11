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
                Thread.Sleep(100);
            }
        }

        static void Method2()
        {
            for (int i = 1; i <= 50; i++)
            {
                WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            /// 1
            Thread thread = new Thread(Method);
            thread.Start();

        }
    }
}
