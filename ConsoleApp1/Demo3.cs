using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Demo3
    {
		// Listening by Using a Wait Handle

		public static void DoSomeWork(CancellationToken cancellationToken)
		{
			Console.WriteLine(DateTime.Now);
			WaitHandle.WaitAny(new WaitHandle[] { cancellationToken.WaitHandle });
			Console.WriteLine(DateTime.Now);
		}

		#region DemoRunner
		public static void RunDoSomeWork(object o)
		{
			CancellationToken cancellationToken = (CancellationToken)o;
			try
			{
                DoSomeWork(cancellationToken);
            }
            catch (OperationCanceledException)
			{
                // NOOP
			}
		}

		public static void Run()
		{
			Console.WriteLine("Demo 3");
			Console.WriteLine();

			using CancellationTokenSource cts = new CancellationTokenSource(5000);
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunDoSomeWork), cts.Token);
			Console.ReadLine();
        }
        #endregion
    }
}

