using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw1606__Task_DemoConnectToDB__Exrice_1
{
    //All Threads Get In The Gate Until I Close Him!
    //class Program
    //{
    //    static ManualResetEvent mre = new ManualResetEvent(false);
    //    static private void CreateCustomer()
    //    {
    //        mre.WaitOne();
    //        Console.WriteLine("Customer Created!");
    //        Thread.Sleep(1000);

    //    }
    //    static private void RemoveOrder()
    //    {
    //        mre.WaitOne();
    //        Console.WriteLine("Your Order Removed");
    //        Thread.Sleep(1000);

    //    }
    //    static private void ConnectToDB()
    //    {
    //        Console.WriteLine("Connection Succesfull!");
    //        Thread.Sleep(3000);
    //        mre.Set();
    //    }
    //    static void Main(string[] args)
    //    {
    //        new Task(CreateCustomer).Start();
    //        new Task(RemoveOrder).Start();
    //        new Task(ConnectToDB).Start();
    //
    //        while (true)
    //        {
    //
    //        }
    //    }


    //Just One Thread Get In The Gate And Close The Gate!
    class Program
    {
        static AutoResetEvent are = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            new Task(() =>
            {
                are.WaitOne();
                Console.WriteLine("Customer Created!");
                Thread.Sleep(1000);
                are.Set();
            }).Start();
            new Task(() =>
            {
                are.WaitOne();
                Console.WriteLine("Your Order Removed");
                Thread.Sleep(1000);
                are.Set();
            }).Start();
            new Task(() =>
            {
                Console.WriteLine("Connection Succesfull!");
                Thread.Sleep(3000);
                are.Set();
            }).Start();
    
            while (true)
            {
    
            }
        }
}
}
