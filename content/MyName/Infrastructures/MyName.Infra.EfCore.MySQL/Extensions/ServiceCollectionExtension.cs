using MyName.Infra.Repository.EfCore.MySql;
using MyName.Infra.Repository.EfCore.MySql.Transaction;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMyNameInfraEfCoreMySql(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
    {
        if (services.HasRegistered(nameof(AddMyNameInfraEfCoreMySql)))
            return services;

        services.TryAddScoped<IUnitOfWork, MySqlUnitOfWork<MySqlDbContext>>();
        services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        services.TryAddScoped(typeof(IEfBasicRepository<>), typeof(EfBasicRepository<>));
        services.AddDbContext<DbContext, MySqlDbContext>(optionsBuilder);

        return services;
    }
}