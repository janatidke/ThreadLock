using System;
using System.Threading;
namespace ThreadDemo
{
    class fileAccess
    {

        public void WriteData(string s)
        {
            lock (this)
            {
                Monitor.Enter(this);
                Console.WriteLine("Writing " + s + " finished");
                Monitor.Exit(this);
            }
        }



    }

    class Program
    {
        static fileAccess obj = new fileAccess();
        public static void childThread1()
        {
            Console.WriteLine("Thread 1");
            obj.WriteData("child1-my new data");
        }
        public static void childThread2()
        {
            Console.WriteLine("Thread2");
            obj.WriteData("child2-my new data");

        }
        static void Main(string[] args)
        {
            ThreadStart ts1 = new ThreadStart(childThread1);
            ThreadStart ts2 = new ThreadStart(childThread2);

            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(ts2);

            t1.Start();
            t2.Start();
        }
    }
}
