using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class ExampleHealthCheck : IHealthCheck
    {
		//public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
		//{
		//	using (var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB"))
		//	{
		//		await sqlConnection.OpenAsync(cancellationToken);
		//	}

		//	return HealthCheckResult.Healthy();
		//}

		#region With "timeout"
		public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
		{
			using var timeoutCancellationSource = new CancellationTokenSource(1000);
			using var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationSource.Token, cancellationToken);
			using var sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB");

			await sqlConnection.OpenAsync(linkedCancellationTokenSource.Token);

			return HealthCheckResult.Healthy();
		}
		#endregion
	}
}
