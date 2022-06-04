using apinet06.Models.Domains;
using apinet06.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apinet06.Models.Repositorys
{
    public class CobrancaRepository : ICobrancaRepository
    {
        private DataContext context;
        
        public CobrancaRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Cobranca> Create(Cobranca entity)
        {
            entity.Client = await context.Client
            .SingleOrDefaultAsync(x=> x.Id == entity.Client.Id);
            await context.Cobranca.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

     
        public async Task<IEnumerable<Cobranca>> get()
        {
            return await context.Cobranca.Include(c=> c.Client)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Cobranca> Get(int id)
        {
             return await context.Cobranca.Include(c=>c.Client)
            .SingleOrDefaultAsync(p=>p.Id == id);
        }

        public async Task Update(Cobranca entity)
        {
             var updateResult = await context.Cobranca
                                .Include(c=>c.Client)
                                .FirstOrDefaultAsync(c=> c.Id == entity.Id);
            context.Entry(updateResult).CurrentValues.SetValues(entity);
           
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var delete = await context.Cobranca.FindAsync(id);
           context.Cobranca.Remove(delete);
           await context.SaveChangesAsync();
        }
    }
}