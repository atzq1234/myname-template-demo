using MyName.Infra.IdGenerater.Yitter;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMyNameInfraYitterIdGenerater(this IServiceCollection services, IConfigurationSection redisSection)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraYitterIdGenerater)))
            return services;

        return services
            .AddMyNameInfraRedis(redisSection)
            .AddSingleton<WorkerNode>()
            .AddHostedService<WorkerNodeHostedService>();
    }
}