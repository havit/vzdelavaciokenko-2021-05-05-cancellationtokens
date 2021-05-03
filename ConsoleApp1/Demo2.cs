using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Demo2
    {
		// Listening by Registering a Callback

		public static void DoSomeWork(CancellationToken cancellationToken)
		{
			WebClient wc = new WebClient();
			wc.DownloadStringCompleted += (s, e) => { Console.WriteLine(e.Cancelled ? "Request was cancelled." : "Request completed."); };

			// Cancellation on the token will call CancelAsync on the WebClient.
			cancellationToken.Register(() =>
			{
				wc.CancelAsync();
			});

			Console.WriteLine("Starting request.");
			wc.DownloadStringAsync(new Uri("http://www.contoso.com"));
		}

		#region DemoRunner
		public static void RunDoSomeWork(object o)
		{
			Console.WriteLine("Demo 2");
			Console.WriteLine();

			CancellationToken cancellationToken = (CancellationToken)o;
			Console.WriteLine(DateTime.Now);
			try
			{
                DoSomeWork(cancellationToken);
            }
            catch (OperationCanceledException)
			{
                // NOOP
			}
			Console.WriteLine(DateTime.Now);
		}

		public static void Run()
		{
			using CancellationTokenSource cts = new CancellationTokenSource(100);
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunDoSomeWork), cts.Token);
			Console.ReadLine();
        }
        #endregion
    }
}

