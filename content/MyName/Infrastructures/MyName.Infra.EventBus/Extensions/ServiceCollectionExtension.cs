using MyName.Infra.EventBus;
using MyName.Infra.EventBus.Cap;
using MyName.Infra.EventBus.Cap.Filters;
using MyName.Infra.EventBus.Configurations;
using MyName.Infra.EventBus.RabbitMq;
using DotNetCore.CAP;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddMyNameInfraCap<TSubscriber>(this IServiceCollection services, Action<CapOptions> setupAction)
        where TSubscriber : class, ICapSubscribe
    {
        if (services.HasRegistered(nameof(AddMyNameInfraCap)))
            return services;
        services
            .AddSingleton<IEventPublisher, CapPublisher>()
            .AddScoped<TSubscriber>()
            .AddCap(setupAction)
            .AddSubscribeFilter<DefaultCapFilter>()
            ;
        return services;
    }


    public static IServiceCollection AddMyNameInfraRabbitMq(this IServiceCollection services, IConfigurationSection rabitmqSection)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraRabbitMq)))
            return services;

        return services
             .Configure<RabbitMqOptions>(rabitmqSection)
             .AddSingleton<IRabbitMqConnection>(provider =>
             {
                 var options = provider.GetRequiredService<IOptions<RabbitMqOptions>>();
                 var logger = provider.GetRequiredService<ILogger<RabbitMqConnection>>();
                 var serviceInfo = services.GetServiceInfo();
                 var clientProvidedName = serviceInfo?.Id ?? "unkonow";
                 return RabbitMqConnection.GetInstance(options, clientProvidedName, logger);
             })
             .AddSingleton<RabbitMqProducer>()
             ;
    }
}