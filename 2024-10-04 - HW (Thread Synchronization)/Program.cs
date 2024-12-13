using System.Text;
using static System.Console;

namespace _2024_10_04___HW__Thread_Synchronization_
{
    class Stat
    {
        public static int Letters = 0;
        public static int Digits = 0;
        public static int Words = 0;
        public static int PunctuationMarks = 0;
        public static int Whitespaces = 0;
        public static int Rows = 0;
        public static int Uppers = 0;
        public static int Lowers = 0;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            string[] files = Directory.GetFiles(@".\Animals");
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < files.Length; i++)
                threads.Add(new Thread(TextAnalyse));
            for (int i = 0; i < files.Length; i++)
                threads[i].Start(File.ReadAllText(files[i]));
            for (int i = 0; i < files.Length; i++)
                threads[i].Join();
            WriteLine($"Letters : {Stat.Letters}\n" +
                      $"Digits : {Stat.Digits}\n" +
                      $"Words : {Stat.Words}\n" +
                      $"Punctuation Marks : {Stat.PunctuationMarks}\n" +
                      $"Whitespaces : {Stat.Whitespaces}\n" +
                      $"Rows : {Stat.Rows}\n" +
                      $"Upper Letters : {Stat.Uppers}\n" +
                      $"Lower Letters : {Stat.Lowers}");
        }

        static void TextAnalyse(object text)
        {
            string text_ = (string)text;
            foreach (char symbol in text_)
            {
                if (char.IsLetter(symbol))
                    Interlocked.Increment(ref Stat.Letters);
                if (char.IsDigit(symbol))
                    Interlocked.Increment(ref Stat.Digits);
                if (char.IsPunctuation(symbol))
                    Interlocked.Increment(ref Stat.PunctuationMarks);
                if (char.IsWhiteSpace(symbol))
                    Interlocked.Increment(ref Stat.Whitespaces);
                if (char.IsUpper(symbol))
                    Interlocked.Increment(ref Stat.Uppers);
                if (char.IsLower(symbol))
                    Interlocked.Increment(ref Stat.Lowers);
            }
            Interlocked.Add(ref Stat.Words, text_.Split([' ', '.', ',', ';', ':', '–', '—', '‒', '…', '!', '?', '"', '`', '«', '»', '(', ')', '{', '}', '[', ']', '<', '>', '/'], StringSplitOptions.RemoveEmptyEntries).Length);
            Interlocked.Add(ref Stat.Rows, text_.Split(['\n']).Length);
        }
    }
}
