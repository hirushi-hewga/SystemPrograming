using System;
using System.Diagnostics;
using static System.Console;

namespace _2024_09_30___Lesson__Processes_
{
    class Program
    {
        static void Main(string[] args)
        {
            Process pr = new Process();

            #region Working with Current Process

            //Process processes = new Process();

            Process current = Process.GetCurrentProcess();

            //Process Proirity:
            // * Idle
            // * BelowNormal
            // * Normal(def)
            // * AboveNormal
            // * High
            // * RealTime(only set by OS)
            // */

            current.PriorityClass = ProcessPriorityClass.High;

            //////////////////////// Process Info
            WriteLine("----------- Current Process Info -----------");
            WriteLine("Priority class : " + current.PriorityClass);
            WriteLine("Name : " + current.ProcessName);
            WriteLine("Id : " + current.Id);
            WriteLine("Machine name : " + current.MachineName);
            WriteLine("Private memory size (KB) : " + current.PrivateMemorySize64 / 1024);
            WriteLine("Start time : " + current.StartTime);
            WriteLine("Total processor time : " + current.TotalProcessorTime);
            WriteLine("User processor time : " + current.UserProcessorTime);

            #endregion
        }
    }
}
