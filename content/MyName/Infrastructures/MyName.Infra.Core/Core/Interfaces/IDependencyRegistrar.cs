namespace MyName.Infra.Core.Interfaces;

public interface IDependencyRegistrar
{
    public string Name { get; }

    public void AddMyName();
}