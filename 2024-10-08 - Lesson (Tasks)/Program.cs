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

    /*
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
    */

    #endregion

    #region ContinuousTasks

    /*
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => {
                Console.WriteLine($"Task Id: {Task.CurrentId}");
                Thread.Sleep(1000);
            });

            // автоматичний запуск завдання після завершення 1-го
            Task task2 = task1.ContinueWith(Display).ContinueWith(Display2);
            
            task1.Start();

            // чекаємо завершення 2-го завдання
            task2.Wait();
            Console.WriteLine("Main is working...");
            Console.ReadLine();
        }

        static void Display(Task prevTask)
        {
            Console.WriteLine($"Task Id: {Task.CurrentId}");
            Console.WriteLine($"Previous Task Id: {prevTask.Id}");
            Thread.Sleep(3000);
        }
        static void Display2(Task prevTask)
        {
            Console.WriteLine("Display 2");
        }
    }
    */

    #endregion

    #region TaskResult

    /**/
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ////////////////// Factorial
            Task<int> task1 = new Task<int>(() => Factorial(5)); // 5! = 1 * 2 * 3 * 4 * 5 = 120
            task1.ContinueWith(Summ);

            task1.Start();

            //task1.Wait();
            Console.WriteLine($"Факторіал числа 5 = {task1.Result}"); // wait until task complete

            ////////////////////// Book
            Task<Book> task2 = new Task<Book>(() =>
            {
                return new Book { Title = "Війна і мир", Author = "Л. Толстой" };
            });

            //string separator = new string('-', 10);
            //Task<Book> task2 = new Task<Book>(
            //    delegate (object obj)
            //    {
            //        Book book = obj as Book;
            //        book.Title = "Deal Souls";
            //        book.Author = "Gogol";
            //        return book;
            //    },
            //    new Book());

            task2.Start();

            Book b = task2.Result;  // ожидаем получение результата
            Console.WriteLine($"Назва книги: {b.Title}, автор: {b.Author}");

            Console.WriteLine("Main continue working...");
            Task.WaitAll(task1, task2);
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
        static int Summ(Task<int> prevTask)
        {
            int summ = prevTask.Result * 2;
            Console.WriteLine(summ);
            return summ;
        }
    }


    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }


    #endregion
}
