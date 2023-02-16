//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using MyName.Infra.Redis.Core.Configurations;

namespace MyName.Infra.Redis.Caching.Interceptor.Castle
{
    public static class CastleInterceptorServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the castle interceptor.
        /// </summary>
        /// <returns>The castle interceptor.</returns>
        /// <param name="services">Services.</param>
        /// <param name="options">MyName.Infra.Redis Interceptor config</param>
        //public static void ConfigureCastleInterceptor(this IServiceCollection services, Action<MyName.Infra.RedisInterceptorOptions> options)
        //{
        //    services.TryAddSingleton<IMyName.Infra.RedisKeyGenerator, DefaultMyName.Infra.RedisKeyGenerator>();
        //    services.Configure(options);
        //}
    }
}