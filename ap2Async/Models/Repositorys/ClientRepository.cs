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

        public async Task<Client> Create(Client entity)
        {
            entity.Cobrancas = await context.Cobranca
            .SingleOrDefaultAsync(x=> x.Id == entity.Cobrancas.Id);
            await context.Client.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Client>> get()
        {
            return await context.Client
            .Include(c=> c.Cobrancas)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Client> Get(int id)
        {
            return await context.Client.Include(c=>c.Cobrancas)
            .SingleOrDefaultAsync(p=>p.Id == id);
        }

        public async Task Update(Client entity)
        {
            var updateResult = await context.Client
                                .Include(c=>c.Cobrancas)
                                .FirstOrDefaultAsync(c=> c.Id == entity.Id);
            context.Entry(updateResult).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
            
        }

         public async Task Delete(int id)
        {
           var delete = await context.Client.FindAsync(id);
           context.Client.Remove(delete);
           await context.SaveChangesAsync();
        }
    }
}