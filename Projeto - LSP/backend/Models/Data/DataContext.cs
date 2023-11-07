using backend.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, "bancoLocal.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source = {DbPath}");

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}