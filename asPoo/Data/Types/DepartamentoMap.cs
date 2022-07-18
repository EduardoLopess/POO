using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.Property(i => i.Id)
                .HasColumnName("id");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();


              
        }
    }
}