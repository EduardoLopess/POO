using apinet06.Models.Domains;

namespace apinet06.Models.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> get();

        Task<Client> Get(int id);

        Task<Client> Create(Client client);

        Task Update(Client client);

        Task Delete(int id);
    }
}