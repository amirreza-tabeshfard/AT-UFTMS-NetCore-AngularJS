namespace AT.UFTMS.WebAPI.Api.BackgroundServices;
public class OutboxBackgroundService(IServiceScopeFactory scopeFactory)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using IServiceScope scope = scopeFactory.CreateScope();
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}