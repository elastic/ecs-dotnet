using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging.Example
{
	/// <summary> Simulate work that logs in low volume with some time in between each log call </summary>
	public class LowVolumeWorkSimulation : BackgroundService
	{
		private readonly ILogger<LowVolumeWorkSimulation> _logger;

		public LowVolumeWorkSimulation(ILogger<LowVolumeWorkSimulation> logger) => _logger = logger;

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var ipAddress = IPAddress.Parse("2001:db8:85a3::8a2e:370:7334");
			var customerId = 12345;
			var orderId = "PO-56789";
			var dueDate = new DateTime(2020, 1, 2);
			var token = new byte[] { 0x12, 0x34, 0xbc, 0xde };
			var checksum = (byte)0x9a;
			var success = true;
			var end = new DateTimeOffset(2020, 1, 2, 3, 4, 5, TimeSpan.FromHours(6));
			var total = 100;
			var rate = 0;

			Thread.CurrentPrincipal = new ClaimsPrincipal(new GenericIdentity("user@example.com"));
			//Trace.CorrelationManager.ActivityId = Guid.NewGuid();

			using (_logger.BeginScope("IP address {ip}", ipAddress))
			{
				try
				{
					using (_logger.BeginScope(new Dictionary<string, object> { ["SecretToken"] = token }))
						Log.SignInToken(_logger, checksum, success, null);

					using (_logger.BeginScope("Customer {CustomerId}, Order {OrderId}, Due {DueDate:yyyy-MM-dd}",
							   customerId, orderId, dueDate))
					{
						Log.StartingProcessing(_logger, 10, null);
						var items = new List<Guid>();
						for (var i = 0; i < 10; i++)
						{
							await Task.Delay(TimeSpan.FromMilliseconds(1000), stoppingToken).ConfigureAwait(false);
							var item = Guid.NewGuid();
							Log.ProcessOrderItem(_logger, item, null);
							items.Add(item);
						}

						using (_logger.BeginScope("{ItemsProcessed}", items))
						{
							_logger.LogWarning("End of processing reached at {EndTime}.", end);
							Log.WarningEndOfProcessing(_logger, end, null);
						}

						try
						{
							// ReSharper disable once IntDivisionByZero
							var _ = total / rate;
						}
						catch (Exception ex)
						{
							throw new Exception("Calculation error", ex);
						}
					}
				}
				catch (Exception ex)
				{
					using (_logger.BeginScope("PlainScope"))
						Log.ErrorProcessingCustomer(_logger, customerId, ex);
				}
			}

			Log.CriticalErrorExecuteFailed(_logger, null);
		}
	}
}
