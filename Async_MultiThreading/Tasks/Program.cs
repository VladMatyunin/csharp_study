using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is: " + Thread.CurrentThread.ManagedThreadId);
            Example1();
            Example2(10);
            Console.ReadLine();
            Example3();
            Console.ReadLine();
            Console.WriteLine("NOW TASK 5");
            Example5();
            Console.ReadLine();
        }

        static void Example1()
        {
            new Task(() => {
                Thread.Sleep(2);
            Console.WriteLine("Hello From Thread: " + Thread.CurrentThread.ManagedThreadId);
            }).Start();
        }

        static void Example2(int x)
        {
            var arifmeticSum = new Task<int>((n) => {
                int sum = 0;
                for(int i = 0; i < (int)n; i++)
                {
                    sum += i;
                }
                return sum;
            }, x);
            arifmeticSum.Start();
            

            //Result calls Wait
            Console.WriteLine("THE RESULT OF ARIFMETIC SUM FROM 0 TO {0} IS {1}",
                 x, arifmeticSum.Result);

        }

        static void Example3()
        {
            Task task1 = new Task((n)=>Execute((int)n), 300);
            task1.Start();
            Task task2 = new Task((n) => Execute((int)n), 200);
            task2.Start();
            Task task3 = new Task((n) => Execute((int)n), 100);
            task3.Start();
            Task.WaitAll(task1, task2, task3);
            //Printed only when all finished
            Console.WriteLine("NOW ALL FINISHED");
            Thread.Sleep(1000);

            task1 = new Task((n) => Execute((int)n), 300);
            task1.Start();
            task2 = new Task((n) => Execute((int)n), 200);
            task2.Start();
            task3 = new Task((n) => Execute((int)n), 100);
            
            Task.WaitAny(task1, task2, task3);
            //Prints if any finished
            Console.WriteLine("ANY FINISHED");
        }
        static long Execute(int x)
        {
            long y = 1;
            for (int i = 1; i < x; i++)
            {
                Thread.Sleep(5);
                y *= i;
            }
            Console.WriteLine("FINISHED THREAD {0}", Thread.CurrentThread.ManagedThreadId);
            return y;
        }
        static void Example4()
        {
            var cts = new CancellationTokenSource();
            int n = 100;
            Task task = new Task((it) => {
                for (int i = 0; i < n; i++) {
                    
                    n--;
                    Thread.Sleep(10);
                }
            }, cts.Token);

        }
        //Test Continue With to start another task,when first is finished
        static void Example5()
        {
            Task<long> task1 = Task.Run(() => Execute(10));
            Task task2 = task1.ContinueWith(task => Console.Write(task1.Result));
        }
    }
}
