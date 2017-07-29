
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starter
{
    class Program
    {
        public static void Main2()
        {
            //returnung Current main ThreadId
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Executing method, passing as a parameter
            //Easiest way to set multithreading
            ThreadPool.QueueUserWorkItem(method => {
                int x = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("THREAD IS {0}, COUNT IS {1}", x, i);
                }
                
            });
            ThreadPool.QueueUserWorkItem(Compute, "HELLO FROM COMPUTE METHOD");
            //pass message to another Thread 
            CallContext.LogicalSetData("name", "Vlad");
            ThreadPool.QueueUserWorkItem(ComputeWithMessaging);

            //Restrict context copying, so "name" will not be seen
            //This fasters server-like apps
            ExecutionContext.SuppressFlow();

            ThreadPool.QueueUserWorkItem(ComputeWithMessaging);

            ExecutionContext.RestoreFlow();
            Console.ReadLine();
        }

        internal static void Compute(Object state)
        {
            Thread.Sleep(2);
            Console.WriteLine("THREAD IS {0}, MESSAGE IS :{1}",Thread.CurrentThread.ManagedThreadId,state);
        }

        //Gets message from context
        static void ComputeWithMessaging(Object state)
        {
            Thread.Sleep(3);
            string message = (string) CallContext.LogicalGetData("name");
            Console.WriteLine("GOT PASSED MESSAGE: " + message);
        }
    }
}
