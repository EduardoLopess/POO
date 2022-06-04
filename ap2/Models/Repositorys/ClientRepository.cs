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

        public void Create(Client entity)
        {
            entity.cobrancas = context.Cobranca.
            SingleOrDefault(x=>x.ClientID == entity.cobrancas.Id);
           
            context.Add(entity);
            context.SaveChanges();    
        }

        public void Delete(int id)
        {
            context.Client.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Client> GetAll()
        {
           return context.Client.Include(c=>c.cobrancas).ToList();
        }

        public Client GetById(int id)
        {
            return context.Client.Include(c=>c.cobrancas).SingleOrDefault(i=>i.Id == id);
        }

        public void Update(Client entity)
        {
            context.Client.Update(entity);
            context.SaveChanges();
        }
    }
}