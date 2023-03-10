using MyName.Shared.Application.Registrar;

namespace MyName.Maint.Application.Registrar;

public sealed class MaintApplicationDependencyRegistrar : AbstractApplicationDependencyRegistrar
{
    public override Assembly ApplicationLayerAssembly => Assembly.GetExecutingAssembly();

    public override Assembly ContractsLayerAssembly => typeof(IDictAppService).Assembly;

    public override Assembly RepositoryOrDomainLayerAssembly => typeof(EntityInfo).Assembly;

    public MaintApplicationDependencyRegistrar(IServiceCollection services) : base(services)
    {
    }

    public override void AddMyName()
    {
        AddApplicaitonDefault();
        //rpc-rest
        var restPolicies = this.GenerateDefaultRefitPolicies();
        AddRestClient<IAuthRestClient>(RpcConsts.UsrService, restPolicies);
        AddRestClient<IUsrRestClient>(RpcConsts.UsrService, restPolicies);

        AddRabbitMqClient();
    }
}