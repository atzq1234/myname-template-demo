using MyName.Infra.Redis;
using MyName.Infra.Redis.Configurations;
using MyName.Infra.Redis.Core;
using MyName.Infra.Redis.Core.Serialization;
using StackExchangeProvider = MyName.Infra.Redis.Providers.StackExchange;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMyNameInfraRedis(this IServiceCollection services, IConfigurationSection redisSection)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraRedis)))
            return services;

        var redisConfig = redisSection.Get<RedisOptions>();
        services.Configure<RedisOptions>(redisSection);
        services.AddSingleton(provider =>
        {
            var serializerType = typeof(ISerializer);
            var scanedAssembly = typeof(ISerializer).Assembly;
            var serializers = scanedAssembly.ExportedTypes.Where(type => type.IsAssignableTo(serializerType) && type.IsNotAbstractClass(true));
            var serializerName = string.IsNullOrWhiteSpace(redisConfig.SerializerName) ? ConstValue.Serializer.DefaultBinarySerializerName : redisConfig.SerializerName;
            var instanceType = serializers.Single(x=>x.Name.Contains(serializerName,StringComparison.CurrentCultureIgnoreCase));
            return ActivatorUtilities.CreateInstance(provider, instanceType) as ISerializer;
        });

        switch (redisConfig.Provider)
        {
            case ConstValue.Provider.StackExchange:
                AddMyNameStackExchange(services);
                break;

            case ConstValue.Provider.ServiceStack:
                break;

            case ConstValue.Provider.FreeRedis:
                break;

            case ConstValue.Provider.CSRedis:
                break;

            default:
                throw new NotSupportedException(nameof(redisConfig.Provider));
        }

        return services;
    }

    public static IServiceCollection AddMyNameStackExchange(IServiceCollection services)
    {
        return
            services
            .AddSingleton<StackExchangeProvider.DefaultDatabaseProvider>()
            .AddSingleton<StackExchangeProvider.DefaultRedisProvider>()
            .AddSingleton<IRedisProvider>(x => x.GetRequiredService<StackExchangeProvider.DefaultRedisProvider>())
            .AddSingleton<IDistributedLocker>(x => x.GetRequiredService<StackExchangeProvider.DefaultRedisProvider>());
    }
}