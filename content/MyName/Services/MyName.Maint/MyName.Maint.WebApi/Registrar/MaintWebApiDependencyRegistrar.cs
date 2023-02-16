using MyName.Shared.WebApi.Registrar;

namespace MyName.Maint.WebApi.Registrar;

public sealed class MaintWebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
{
    public MaintWebApiDependencyRegistrar(IServiceCollection services) 
        : base(services)
    {
    }

    public MaintWebApiDependencyRegistrar(IApplicationBuilder app)
    : base(app)
    {
    }

    public override void AddMyName()
    {
        AddWebApiDefault();
        AddHealthChecks(true, true, true, true);
        Services.AddGrpc();
    }

    public override void UseMyName()
    {
         UseWebApiDefault(endpointRoute: endpoint =>
        {
            endpoint.MapGrpcService<Grpc.MaintGrpcServer>();
        });
    }
}