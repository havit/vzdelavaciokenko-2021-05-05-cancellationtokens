using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Demo4
    {
		public static void Run()
		{
			Console.WriteLine("Demo 4");
			Console.WriteLine();

			using (CancellationTokenSource cts = new CancellationTokenSource())
			{
				// --> cts.Token
				// --> cts.Cancel();
				// --> cts.CancelAfter(...)			

				//		ThreadPool.QueueUserWorkItem(new WaitCallback(RunDoSomeWork), cts.Token);
				Console.ReadLine();
			}
        }
    }
}

