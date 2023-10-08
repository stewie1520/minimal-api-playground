using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace playground.Infrastructures.HealthCheck;

public static class HealthCheckEndpointRouteBuilderExtensions
{
    public static void MapCustomHealthCheck(
        this WebApplication app, string readyPattern = "health/ready", string livePattern = "health/live")
    {
        app.MapHealthChecks(readyPattern, new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("ready")
        });

        app.MapHealthChecks(livePattern, new HealthCheckOptions
        {
            Predicate = _ => false
        });
    }
}