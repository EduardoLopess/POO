using apinet06.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace apinet06.Models.Repositorys
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){}

        public DbSet<Client> Client {get; set;}

    }
}