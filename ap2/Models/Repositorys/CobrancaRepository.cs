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
        

        public void Create(Cobranca entity)
        {
            entity.Client = context.Client.SingleOrDefault(x=>x.Id == entity.Client.Id);
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Cobranca.Remove(GetById(id));
            context.SaveChanges();        }

        public List<Cobranca> GetAll()
        {
            return context.Cobranca.Include(c=>c.Client).ToList();
        }

        public Cobranca GetById(int id)
        {
            return context.Cobranca.Include(c=>c.Client).SingleOrDefault(i=>i.Id == id);
        }

        public void Update(Cobranca entity)
        {
            context.Cobranca.Update(entity);
            context.SaveChanges();
        }
    }
}