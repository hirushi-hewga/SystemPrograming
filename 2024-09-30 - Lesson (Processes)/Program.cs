using System;
using System.Diagnostics;
using static System.Console;

namespace _2024_09_30___Lesson__Processes_
{
    class Program
    {
        static void Method1()
        {
            for (int i = 0; i < 100; i++)
            {
                WriteLine($"\t\t\t{i} - Hello in thread");
                Thread.Sleep(50);
            }
        }

        static void Method2()
        {
            //Reference of current thread
            Thread ThisThread = Thread.CurrentThread;
            //ID of current thread
            WriteLine("ID of background thread : " + ThisThread.GetHashCode());

            for (int i = 0; i < 50; i++)
            {
                WriteLine($"\t\t\t{i} - Hello in thread");
                //Delay current thread in milliseconds
                Thread.Sleep(100);
            }
        }

        static void Method3()
        {
            for (int i = 0; i < 100; i++)
            {
                WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static void Method4()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    //crush
                    WriteLine(i.ToString());
                    //close
                }
            }
            catch (ThreadAbortException e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                WriteLine("End Thread Work");
            }
        }

        static void Method5(object str)
        {
            string text = (string)str;
            for (int i = 0; i < 200; i++)
            {
                WriteLine("{0} #{1}", text, i.ToString());
            }
        }

        static void InfinityLoop()
        {
            WriteLine("Thread has been started!");
            while (true)
            {
                int a = 5;
                int b = a;
                int c = a + b;
                new Random().Next(100);
            }
        }

        static void ThreadFunk(object a)
        {
            string ID = (string)a;
            for (int i = 0; i < 100; i++)
            {
                WriteLine(ID + " " + i);
                //ReadKey();
                Thread.Sleep(50);
            }
        }

        static void Main(string[] args)
        {
            #region thread_without_params

            /*
            //ThreadStart threadstart = new ThreadStart(Method1);
            //// ParameterizedThreadStart
            //Thread thread = new Thread(thread_start);
            //thread.Priority = ThreadPriority.Lowest;
            //ThreadStart threadstart = new ThreadStart(Method1);
            //ThreadStart threadstart = Method1;
            Thread thread = new Thread(Method1);
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
            //Method1(); // freeze
            for (int i = 0; i < 100; i++)
            {
                WriteLine($"{i} - Hello in main");
                Thread.Sleep(50);
            }
            */

            #endregion

            #region thread_with_params

            /*
            //int start = 10;
            //int end = 2;
            //Tuple<int, int> tuple = new Tuple<int, int> (start, end);

            //Thread thread = new Thread()

            //ParameterizedThreadStart threadstart = new ParameterizedThreadStart(ThreadFunk);
            Thread thread1 = new Thread(ThreadFunk);
            thread1.Start((object)"One");


            Thread thread2 = new Thread(ThreadFunk);
            thread2.Priority = ThreadPriority.Highest;
            thread2.Start("\t\tTwo");

            ///ReadKey();
            WriteLine("End!");
            */

            #endregion

            #region thread_in_background

            /*
            //Primary and secondary threads
            ThreadStart ts = new ThreadStart(Method2);
            Thread t = new Thread(ts);
            t.IsBackground = true; // default - false
            t.Start();

            WriteLine("ID of primary thread : " + Thread.CurrentThread.GetHashCode());

            ReadKey();
            WriteLine("Main end!");
            */

            #endregion

            #region thread_pause

            /*
            ThreadStart ts = new ThreadStart(Method3);
            Thread t = new Thread(ts);
            t.Start(); // Thread start
            WriteLine("Press any key to pause thread...");

            ReadKey();
            t.Suspend(); // Thread pause
            WriteLine("Thread is stoped!");
            WriteLine("Press any key to resume thread");

            ReadKey();
            t.Resume(); // Thread resume
            */

            #endregion

            #region thread_force_quit

            /*
            ThreadStart ts = new ThreadStart(Method4);
            Thread t = new Thread(ts);
            t.IsBackground = true;
            t.Start();

            WriteLine("Press any key to force quit thread...");

            ReadKey();
            t.Abort();
            */

            #endregion

            #region thread_priority

            /* Thread priorities
                * Highest
                * AboveNormal
                * Normal (default)
                * BelowNormal
                * Lowest
            */

            /*
            ParameterizedThreadStart ts = new ParameterizedThreadStart(Method5);

            Thread t1 = new Thread(ts);
            Thread t2 = new Thread(ts);

            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;

            ReadKey();
            t1.Start((object)"t1 : Lowest");
            t2.Start((object)"\t\t\tt2 : Highest");
            WriteLine("Hello top");
            ReadKey();
            WriteLine("Hello bottom");
            */

            #endregion

            #region threads

            /**/
            ConsoleKeyInfo input;
            do
            {
                Thread thread = new Thread(InfinityLoop);
                thread.Start();
                //InfinityLoop();
                input = ReadKey();
            } while (input.Key != ConsoleKey.Escape);


            #endregion
        }
    }
}
