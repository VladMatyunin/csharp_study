using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starter
{
    class ProgramWithCancel
    {
        public static void Main()
        {
            //register cancellationToken
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            //pass it as method parameter
            ThreadPool.QueueUserWorkItem(method=>ProcessWithCancellation(tokenSource.Token, "MESSAGE IS TO CONTINUE"));
            Console.WriteLine("PRESS ANY KEY TO STOP ANOTHER PROCESS");
            Console.ReadLine();
            //stop process
            tokenSource.Cancel();

            Console.WriteLine("STOPPED");
            Console.ReadLine();
        }

        //writing message until not stopped
        private static void ProcessWithCancellation(CancellationToken cancelToken, string message)
        {
            for(int i = 0; i < 100; i++)
            {
                //check if cancel is requested
                if (cancelToken.IsCancellationRequested)
                    break;
                Thread.Sleep(100);
                Console.WriteLine(message);
            }
        }
        private static void TestWithRegister()
        {
            Action func = ()=> {
                Console.WriteLine("GOT IN THE METHOD");
            };
            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(func);
        }
    }
}
