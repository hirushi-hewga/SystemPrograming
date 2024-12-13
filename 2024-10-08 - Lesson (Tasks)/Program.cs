using System.Text;

namespace _2024_10_08___Lesson__Tasks_
{
    #region Task

    /*
    // * AsyncState : повертає об'єкт стану завдання
    // * CurrentId  : повертає ідентифікатор поточного завдання
    // * Exception  : повертає об'єкт виключення, що виник при виконанні завдання
    // * Status     : повертає статус завдання

    // TPL - Task Parallel Library

    class Program
    {
        static void Main(string[] args)
        {
            //ThreadStart
            //ParameterizedThreadStart
            //Thread thread = new Thread();
            //Action
            Console.OutputEncoding = Encoding.UTF8;
            Task tack = new Task(() =>
            {
                Console.WriteLine("Початок роботи метода Display");
                // ...
                Console.WriteLine("Завершення роботи метода Display");
            });

            Task task1 = new Task(() => Console.WriteLine($"Task 1 is executed in Thread: {Thread.CurrentThread.ManagedThreadId}"));
            task1.Start();

            // start automatically
            Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Task 2 is executed in Thread: {Thread.CurrentThread.ManagedThreadId}"));
            // start automatically
            Task task3 = Task.Run(() =>
            {
                Console.WriteLine($"Task 3 is executed in Thread: {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.ReadKey();

            Task task = new Task(Display);
            task.Start();
            task.Wait(); // waiting... (freez)

            Console.WriteLine("Завершення метода Main");

            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine("Початок роботи метода Display");
            // ...
            Console.WriteLine("Завершення роботи метода Display");
        }
    }
    */

    #endregion

    #region TaskArray

    /**/
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
            };
            foreach (var t in tasks1)
                t.Start();

            Task.WaitAll(tasks1); // waiting all tasks
            Console.WriteLine("All Tasks have done!");

            Task[] tasks2 = new Task[3];

            int j = 1;
            for (int i = 0; i < tasks2.Length; i++)
                tasks2[i] = Task.Run(() =>
                {
                    Thread.Sleep(rnd.Next(5000));
                    Console.WriteLine($"Task {j++}");
                });

            Task.WaitAny(tasks2); // waiting any one task
            Console.WriteLine("Some Task has done!");

            Console.ReadLine();
        }
    }


    #endregion
}
