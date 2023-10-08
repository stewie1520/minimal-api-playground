using Microsoft.Extensions.Diagnostics.HealthChecks;
using playground.Common.Interfaces;

namespace playground.Infrastructures.HealthCheck;

public class DbHealthCheck(IApplicationDbContext dbContext) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        var dbOk = await dbContext.CanConnectAsync(CancellationToken.None);
        if (!dbOk)
            return new HealthCheckResult(
                context.Registration.FailureStatus, "can't connect to database");

        return HealthCheckResult.Healthy();
    }
}