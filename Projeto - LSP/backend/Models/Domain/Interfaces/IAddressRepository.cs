using backend.Models.Domain.Entities;

namespace backend.Models.Domain.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task CreateAsync(Address entity);
    }
}