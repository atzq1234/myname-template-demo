using MyName.Shared.WebApi.Registrar;
using MyName.Usr.WebApi.Authentication;
using MyName.Usr.WebApi.Authorization;

namespace MyName.Usr.WebApi.Registrar;

public sealed class UsrWebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
{
    public UsrWebApiDependencyRegistrar(IServiceCollection services)
        : base(services)
    {
    }

    public UsrWebApiDependencyRegistrar(IApplicationBuilder app)
        : base(app)
    {
    }

    public override void AddMyName()
    {
        AddWebApiDefault<BearerAuthenticationLocalProcessor, PermissionLocalHandler>();
        AddHealthChecks(true, true, true, false);
        Services.AddGrpc();
    }

    public override void UseMyName()
    {
        UseWebApiDefault(endpointRoute: endpoint =>
        {
            endpoint.MapGrpcService<Grpc.AuthGrpcServer>();
            endpoint.MapGrpcService<Grpc.UsrGrpcServer>();
        });
    }
}