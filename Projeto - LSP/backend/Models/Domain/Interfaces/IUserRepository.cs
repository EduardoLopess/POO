using backend.Models.Domain.Entities;

namespace backend.Models.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task CreateAsync(User entity, Address address);
    }
}