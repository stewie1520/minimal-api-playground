using System.Reflection;

namespace playground.Infrastructures;

public static class WebAppExtension
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name;

        return app.MapGroup($"api/{groupName}")
          .WithGroupName(groupName)
          .WithTags(groupName)
          .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);
        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes().Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var endpointGroup in endpointGroupTypes)
        {
            var group = Activator.CreateInstance(endpointGroup) as EndpointGroupBase;
            group?.Map(app);
        }

        return app;
    }
}