namespace playground.Infrastructures.HealthCheck;

public static class HeathCheckServiceExtension
{
    public static void AddCustomHealthCheck(this IServiceCollection services)
    {
        services.AddHealthChecks().AddCheck<DbHealthCheck>("database", tags: new[] { "ready" });
    }
}