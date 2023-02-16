using MyName.Infra.Mapper;
using MyName.Infra.Mapper.AutoMapper;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMyNameInfraAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraAutoMapper)))
            return services;

        services.AddAutoMapper(profileAssemblyMarkerTypes);
        services.AddSingleton<IObjectMapper, AutoMapperObject>();
        return services;
    }

    public static IServiceCollection AddMyNameInfraAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraAutoMapper)))
            return services;

        services.AddAutoMapper(assemblies);
        services.AddSingleton<IObjectMapper, AutoMapperObject>();
        return services;
    }
}