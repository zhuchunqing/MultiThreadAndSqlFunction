using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public delegate void MethodA(string s);
        public delegate int MethodB(string s);
        static Semaphore _sem = new Semaphore(3, 3);    // Capacity of 3
        static void Main(string[] args)
        {
            //MethodA a = new MethodA(ThreadFuncOne);
            Thread.CurrentThread.Name = "MainThread";
            Thread child = new Thread(()=>ThreadFuncOne("qeweqw"));
            child.Name = "childThread";
            var childChild = Task.Run(() => ThreadFuncOne("childChild"));
            childChild.Start();
            Console.WriteLine("ThreadFuncOne Return="+ childChild); 
            for (int j = 0; j < 20; j++)
            {
                if (j == 10)
                {
                    child.Start();
                    Console.WriteLine("ThreadFuncOne Return=");
                    child.Join();
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "   j =  " + j);
                }
            }
            Console.Read();
        }
        static string ThreadFuncOne(string aa)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "   i =  " + i+"aa="+aa);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " has finished");
            return "ThreadFuncOne";
        }
        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.WaitOne();
            Console.WriteLine(id + " is in!");           // Only three threads
            Thread.Sleep(1000 * (int)id);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            _sem.Release();
        }
    }
}
