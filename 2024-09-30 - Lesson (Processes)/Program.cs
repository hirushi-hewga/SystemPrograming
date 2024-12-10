using System;
using System.Diagnostics;
using static System.Console;

namespace _2024_09_30___Lesson__Processes_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process pr = new Process();

            #region Working with Current Process

            ////Process processes = new Process();

            //Process current = Process.GetCurrentProcess();

            ////Process Proirity:
            //// * Idle
            //// * BelowNormal
            //// * Normal(def)
            //// * AboveNormal
            //// * High
            //// * RealTime(only set by OS)
            //// */

            //current.PriorityClass = ProcessPriorityClass.High;

            ////////////////////////// Process Info
            //WriteLine("----------- Current Process Info -----------");
            //WriteLine("Priority class : " + current.PriorityClass);
            //WriteLine("Name : " + current.ProcessName);
            //WriteLine("Id : " + current.Id);
            //WriteLine("Machine name : " + current.MachineName);
            //WriteLine("Private memory size (KB) : " + current.PrivateMemorySize64 / 1024);
            //WriteLine("Start time : " + current.StartTime);
            //WriteLine("Total processor time : " + current.TotalProcessorTime);
            //WriteLine("User processor time : " + current.UserProcessorTime);

            #endregion

            #region All Processes

            //Process[] processes = Process.GetProcesses();

            //WriteLine("Process name\t\t\tPID\t\t\tPriority\tMachine name");
            //WriteLine("----------------------------------------------------------");
            //foreach (var p in processes)
            //{
            //    try
            //    {
            //        WriteLine($"{p.ProcessName,15}\t{p.Id,10}\t{p.BasePriority,15}\t{p.StartTime,20}");
            //    }
            //    catch
            //    {
            //        ForegroundColor = ConsoleColor.Red;
            //        WriteLine($"Error with {p.ProcessName}");
            //        Console.ResetColor();
            //    }
            //}

            #endregion

            #region Start Process

            //Process.Start("Chrome.exe", "stackoverflow.com google.com");
            //Process.Start("Calc.exe");

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = @"notepad",
                Arguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\777.txt",
                WindowStyle = ProcessWindowStyle.Maximized
            };

            Process pr = Process.Start(info);

            WriteLine("Press key to do operation...");
            ReadKey();


            ////////////////////// Process Methods
            //pr.Close();                       // clear resources
            //pr.Refresh();                     // clear cashe
            //pr.CloseMainWindow();             // close process by normal mode = Alt+F4
            //pr.Kill();                        // imediatelly stops a process = End Task
            //WriteLine("Operation has done!");

            //WriteLine("Wait for exit...");
            //pr.WaitForExit();
            //WriteLine("Process was exited...");
            //WriteLine("Exit code : " + pr.ExitCode);
            //WriteLine("Exit time : " + pr.ExitTime);

            #endregion
        }
    }
}
