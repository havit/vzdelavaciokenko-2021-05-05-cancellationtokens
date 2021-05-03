using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication15.Controllers
{
	[ApiController]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		[Route("/")]
		public async Task<string> Get(int id, CancellationToken cancellationToken)
		{
			// id not used
			try
			{
				await Task.Delay(10000, cancellationToken);
				return "Server completed.";
			}
			catch (OperationCanceledException)
			{
				return "Server cancelled.";
			}
		}
	}
}
