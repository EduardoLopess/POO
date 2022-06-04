using apinet06.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace apinet06.Models.Repositorys
{
  
    public class DataContext : DbContext
    {
  
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Client> Client {get; set;}

        public DbSet<Cobranca> Cobranca {get; set;}
    }
}



