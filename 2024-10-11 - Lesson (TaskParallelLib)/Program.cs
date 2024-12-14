using System.Text;

namespace _2024_10_11___Lesson__TaskParallelLib_
{
    #region Parallel

    /*
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                Display,
                () => {
                    Console.WriteLine($"Task executing {Task.CurrentId}");
                    Thread.Sleep(3000);
                    Console.WriteLine($"Task ended  {Task.CurrentId}");
                },
                () => Factorial(5));

            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Task ended {Task.CurrentId}");
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Result {result}");
        }
    }
    */

    #endregion

    #region ParallelFor

    /*
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine("Started!");

            //for (int i = 0; i < 20; i++)
            //{
            //    Factorial(i);
            //}

            //for (int i = 1; i < 20; i++)
            //{
            //    int n = i;
            //    Task.Run(() => Factorial(n));
            //}

            // itertions: [1...19]
            Parallel.For(1, 20, Factorial);

            Console.ReadLine();
        }

        static void Factorial(int x)
        {
            Random r = new Random();
            for (int i = 0; i < 100_000_000; i++)
            {
                r.Next();
                r.GetHashCode();
                r.NextDouble();
            }

            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            Console.WriteLine($"Task executing {Task.CurrentId}");
            //Thread.Sleep(3000);
            Console.WriteLine($"Factorial {x} = {result}");
        }
    }
    */

    #endregion

    #region ParallelForEach

    /*
    class Program
    {
        static Random rnd = new Random();
        public class Author
        {
            public string Name { get; set; }
            public int[] ratings;
            public Author(string name = "no name")
            {
                Name = name;
                ratings = new int[5]
                {
                    rnd.Next(6),
                    rnd.Next(6),
                    rnd.Next(6),
                    rnd.Next(6),
                    rnd.Next(6)
                };
            }
        }
        static void Main(string[] args)
        {
            //var list = new List<int>() { 1, 3, 5, 8 };
            //Parallel.ForEach(list, Factorial);

            List<Author> authors = new List<Author>()
            {
                new Author("William"),
                new Author("Roberto"),
                new Author("Harry"),
                new Author("William"),
                new Author("Roberto"),
                new Author("Harry"),
                new Author("Roberto"),
                new Author("William"),
                new Author("Roberto"),
                new Author("Harry"),
                new Author("Roberto"),
                new Author("William"),
                new Author("William"),
                new Author("William")
            };

            //foreach (var a in authors)
            //{
            //    AverageRating(a);
            //}

            //Parallel.ForEach(authors, AverageRating);

            DateTime start = DateTime.Now;
            ParallelLoopResult result = Parallel.ForEach(authors, AverageRating);

            if (result.IsCompleted)
            {
                Console.WriteLine("Duration: " + (DateTime.Now - start).TotalSeconds);
                Console.WriteLine("All Tasks had comple ted!");
            }

            Console.ReadLine();
        }

        static void AverageRating(Author author)
        {
            var avg = author.ratings.Average();
            Thread.Sleep(3000);
            Console.WriteLine($"Author {author.Name} average rating = {avg}");
        }
        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Factorial {x} = {result}");
        }
    }
    */

    #endregion

    #region ParallelBreak

    /*
    // * ParallelLoopResult
    // * IsCompleted          : определяет, завершилось ли полное выполнение параллельного цикла
    // * LowestBreakIteration : возвращает индекс, на котором произошло прерывание работы цикла

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ParallelLoopResult result = Parallel.For(1, 10, Factorial);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации " +
                    $"{result.LowestBreakIteration}");
            else
                Console.WriteLine("All iteration ended.");
            Console.ReadLine();
        }
        static void Factorial(int x, ParallelLoopState pls)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
                if (i == 5)
                    pls.Break();
            }
            Console.WriteLine($"Task executing {Task.CurrentId}");
            Console.WriteLine($"Факторіал числа {x} = {result}");
        }
    }
    */

    #endregion

    #region ParallelBreak

    /**/
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Console.OutputEncoding = Encoding.UTF8;

            int number = 6;

            Task task1 = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task was canceled!");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"The factorial of {i} = {result}");
                    Thread.Sleep(2000);
                }

            }, token);

            task1.Start();

            Console.WriteLine("Press any key to stop the task:");
            Console.ReadKey();
            cancelTokenSource.Cancel();

            Console.WriteLine("Press any key to stop the App");
            Console.ReadKey();
        }
    }


    #endregion
}
