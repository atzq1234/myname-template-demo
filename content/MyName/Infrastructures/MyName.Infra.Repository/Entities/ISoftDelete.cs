namespace MyName.Infra.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}