using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw1606___TaskTime_Exrice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            Task t1 = new Task<int>(() =>
            {
                int time = r.Next(1000, 2000);
                Thread.Sleep(time);
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} Wait: {time} miliseconds!");
                return time;
            });

            Task t2 = new Task<int>(() =>
            {
                int time = r.Next(1000, 2000);
                Thread.Sleep(time);
                Console.WriteLine($"Thread Id {Thread.CurrentThread.ManagedThreadId}, Wait: {time} miliseconds!");
                return time;
            });
            t1.Start();
            t2.Start();

            //*****  Wait For All Tasks.
            //Task.WaitAll(t1, t2);
            Console.WriteLine("All Threads As Been Done");

            //*****  Wait Just For One Thread.
            Task.WaitAny(t1, t2);
            Console.WriteLine((t1.IsCompleted ? "Task Number 1" : "Task Number 2") + " Is Over!");
        }
    }
}
