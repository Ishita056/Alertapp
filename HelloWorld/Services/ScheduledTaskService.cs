//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using HelloWorld.Data;

//namespace HelloWorld.Services
//{
//    public class ScheduledTaskService : BackgroundService
//    {
//        private readonly IServiceScopeFactory _scopeFactory;
//        private readonly ILogger<ScheduledTaskService> _logger;

//        public ScheduledTaskService(IServiceScopeFactory scopeFactory, ILogger<ScheduledTaskService> logger)
//        {
//            _scopeFactory = scopeFactory;
//            _logger = logger;
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                try
//                {
//                    using (var scope = _scopeFactory.CreateScope())
//                    {
//                        var context = scope.ServiceProvider.GetRequiredService<HelloWorldContext>();

//                        var alertsToActivate = context.Alert
//                            .Where(a => a.PublishDate <= DateTime.Now && !a.IsActive)
//                            .ToList();

//                        foreach (var alert in alertsToActivate)
//                        {
//                            alert.IsActive = true;
//                            context.Alert.Update(alert);
//                            await context.SaveChangesAsync();
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError(ex, "Error occurred while activating alerts.");
//                }

//                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Check every minute
//            }
//        }
//    }
//}
