using MyName.Infra.Entities;
using MyName.Infra.Repository.Mongo.Configuration;

namespace MyName.Infra.Repository.Mongo.Interfaces
{
    /// <summary>
    /// Mongo entity configuration.
    /// </summary>
    public interface IMongoEntityConfiguration<TEntity>
        where TEntity : MongoEntity
    {
        void Configure(MongoEntityBuilder<TEntity> context);
    }
}