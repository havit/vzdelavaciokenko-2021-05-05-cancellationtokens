using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Demo1
    {
		// Listening by Polling

		public static async Task DoSomeWork(CancellationToken cancellationToken)
		{
			while (true)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					Console.WriteLine("Cancellation has been requested...");
					break;
				}

				// Simulate some work.
				Console.WriteLine("Processing...");
				await Task.Delay(5000, cancellationToken);
			}
		}

		#region Task<int>
		//public static async Task<int> DoSomeWork(CancellationToken cancellationToken)
		//{
		//	if (cancellationToken.IsCancellationRequested)
		//	{
		//		Console.WriteLine("Cancellation has been requested...");
		//		return 1;
		//	}

		//	await Task.Delay(5000, cancellationToken);
		//	return 0;
		//}
		#endregion

		#region DemoRunner
		public static async void RunDoSomeWork(object o)
		{
			CancellationToken cancellationToken = (CancellationToken)o;
			Console.WriteLine(DateTime.Now);
			try
			{
                await DoSomeWork(cancellationToken);
            }
            catch (OperationCanceledException)
			{
                // NOOP
			}
			Console.WriteLine(DateTime.Now);
		}

		public static void Run()
		{
			Console.WriteLine("Demo 1");
			Console.WriteLine();

			using CancellationTokenSource cts = new CancellationTokenSource();
			cts.CancelAfter(6000);
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunDoSomeWork), cts.Token);
			Console.ReadLine();
        }
        #endregion
    }
}

// TODO: Výchozí běh
// TODO: Propagace
// TODO: Default

