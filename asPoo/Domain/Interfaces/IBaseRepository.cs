namespace Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> getAsync();
        Task <Entity> getByIdAsync(int id);
        Task <Entity> createAsync(Entity entity);
        Task updateAsync(Entity entity);
        Task deleteAsync(int id);
    }
}