using MyName.Infra.Redis.Caching;
using MyName.Infra.Redis.Caching.Configurations;
using MyName.Infra.Redis.Caching.Core.Interceptor;
using MyName.Infra.Redis.Caching.Interceptor.Castle;
using MyName.Infra.Redis.Caching.Provider;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMyNameInfraRedisCaching(this IServiceCollection services, IConfigurationSection redisSection, IConfigurationSection cachingSection)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraRedisCaching)))
            return services;

        return services
            .AddMyNameInfraRedis(redisSection)
            .Configure<CacheOptions>(cachingSection)
            .AddSingleton<ICacheProvider, DefaultCachingProvider>()
            .AddSingleton<ICachingKeyGenerator, DefaultCachingKeyGenerator>()
            .AddScoped<CachingInterceptor>()
            .AddScoped<CachingAsyncInterceptor>();
    }
}