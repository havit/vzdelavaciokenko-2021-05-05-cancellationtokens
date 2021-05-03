using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	class Program
	{
		private static readonly HttpClient client = new HttpClient();

		public static async Task Main(string[] args)
		{
			string result = await client.GetStringAsync("http://localhost:57726/");
			Console.WriteLine(result);
		}

		#region With CancellationTokenSource
		//public static async Task Main(string[] args)
		//{
		//	using (CancellationTokenSource cts = new CancellationTokenSource(2000))
		//	{
		//		try
		//		{
		//			string result = await client.GetStringAsync("http://localhost:57726/", cts.Token);
		//			Console.WriteLine(result);
		//		}
		//		catch (OperationCanceledException)
		//		{
		//			Console.WriteLine("Client cancelled.");
		//		}
		//	}
		//}
		#endregion
	}
}