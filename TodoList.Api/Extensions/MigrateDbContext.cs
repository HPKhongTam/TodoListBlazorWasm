using Microsoft.EntityFrameworkCore;

namespace TodoList.Api.Extensions
{
//    public class MigrateDbContext<TContext> : IHostedService where TContext : DbContext
//    {
//        private readonly IServiceProvider _serviceProvider;
//        private readonly ILogger<MigrateDbContext<TContext>> _logger;

//        public MigrateDbContext(IServiceProvider serviceProvider, ILogger<MigrateDbContext<TContext>> logger)
//        {
//            _serviceProvider = serviceProvider;
//            _logger = logger;
//        }

//        public async Task StartAsync(CancellationToken cancellationToken)
//        {
//            _logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

//            using var scope = _serviceProvider.CreateScope();
//            var scopedServices = scope.ServiceProvider;
//            var context = scopedServices.GetRequiredService<TContext>();

//            try
//            {
//                await context.Database.MigrateAsync(cancellationToken);
//                _logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
//            }
//        }

//        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
//    }
}
