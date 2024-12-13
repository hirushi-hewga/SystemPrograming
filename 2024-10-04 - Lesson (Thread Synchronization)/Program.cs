namespace _2024_10_04___Lesson__Thread_Synchronization_
{
    /*
    ■ Thread 1 reads count into register → 0
    ■ Thread 1 increments the register value → 1
    ■ Scheduler disables Thread 1
    ■ Scheduler connects Thread 2
    ■ Thread 2 reads count into register → 0
    ■ Thread 2 increases the value of the register → 1
    ■ Thread 2 stores the value in memory → 1
    ■ Scheduler disables Thread 2
    ■ Scheduler connects Thread 1
    ■ Thread 1 saves the value to memory → 1
    */



    /*
        public static Int32 Increment(ref Int32 location); – увеличивает значение на 1;
        public static int Decrement(ref int location); – уменьшает значение на 1;
        public static int Add(ref int location, int value); – увеличивает/уменьшает значение на value;
        public static int Exchange(ref int locationi, int value); – обменивает параметры значениями;
        public static int CompareExchange(ref int location, 
            int value, int comparand) – сравнивает location и comparand и 
                                        присваивает location value в случае успеха.
    */



    /*
        static void Enter(object obj);

        static bool TryEnter(object obj);
        static bool TryEnter(object obj, int millisecondsTimeout);
        static bool TryEnter(object obj, TimeSpan timeout);
     
        static void Exit(object obj); SynchronizationLockException
     */


    class Counter
    {
        public static int count = 0; // 0 -> 1
                                     // 0 -> 1
                                     // 1 -> 1
    }

    class LockCounter
    {
        int number;
        int evenNumbers;
        public int Number { get { return number; } }
        public int EvenNumbers { get { return evenNumbers; } }
        public void UpdateFields()
        {
            for (int i = 0; i < 1_000_000; ++i)
            {
                lock (this)
                {
                    ++number;
                    if (number % 2 == 0)
                        ++evenNumbers;
                }
            }
        }
    }

    class MonitorLockCounter
    {
        int number;
        int even;
        public int Number { get { return number; } }
        public int Even { get { return even; } }
        public void UpdateFields()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                //Monitor.Enter(this);

                //string str = null; str.ToString(); // NullReferenceException

                //++number;
                //if (number % 2 == 0)
                //    ++even;

                //Monitor.Exit(this);

                Monitor.Enter(this); // block this class fileds in other threads
                try
                {
                    ++number;
                    if (number % 2 == 0)
                        ++even;
                }
                finally
                {
                    Monitor.Exit(this); // unblock
                }
            }
        }
    }


    class Program
    {
        //static void Function()
        //{
        //    for (int j = 1; j <= 1_000_000; ++j)
        //        ++Counter.count;
        //}

        static void Main(string[] args)
        {
            #region sync_problem

            /*
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 1; j <= 1_000_000; ++j)
                        ++Counter.count;
                });
                threads[i].Start();
                //threads[i].Join(); // wait - freez
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join(); // wait

            Console.WriteLine("counter = {0}", Counter.count); // 5_000_000
            */

            #endregion

            #region interlocker

            /*
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(delegate ()
                {
                    for (int j = 1; j <= 1_000_000; ++j)
                    {
                        Interlocked.Increment(ref Counter.count);
                    }
                });
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();
            
            Console.WriteLine("counter = {0}", Counter.count);
            */

            #endregion

            #region lock

            /*
            Console.WriteLine($"Lock Sync:");
            LockCounter c = new LockCounter();

            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(c.UpdateFields);
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Field1: {0}, Field2: {1}\n\n", c.Number, c.EvenNumbers); // 5M 2.5M
            */

            #endregion
        }
    }
}
