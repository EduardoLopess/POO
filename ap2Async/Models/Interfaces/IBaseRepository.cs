namespace apinet06.Models.Interfaces
{
    public interface IBaseRepository<Entity>
        where Entity : class
    {
        Task<IEnumerable<Entity>> get();

        Task<Entity> Get(int id);

        Task<Entity> Create(Entity entity);

        Task Update(Entity entity);

        Task Delete(int id);

    }
}