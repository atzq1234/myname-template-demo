using MyName.Infra.IRepositories;

namespace MyName.Infra.Entities;

public interface IEntityInfo
{
    Operater GetOperater();

    void OnModelCreating(dynamic modelBuilder);
}