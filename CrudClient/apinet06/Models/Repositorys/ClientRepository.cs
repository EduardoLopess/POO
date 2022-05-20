using apinet06.Models.Domains;
using apinet06.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apinet06.Models.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private DataContext context;

        public ClientRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Client> Create(Client client)
        {
            context.Client.Add(client);
            await context.SaveChangesAsync();
            return client;
        }

        public async Task Delete(int id)
        {
           var delete = await context.Client.FindAsync(id);
           context.Client.Remove(delete);
           await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> get()
        {
            return await context.Client.ToListAsync();
        }

        public async Task<Client> Get(int id)
        {
             return await context.Client.FindAsync(id);
                Include(c=>c.cobranca);
        }

        public async Task Update(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}