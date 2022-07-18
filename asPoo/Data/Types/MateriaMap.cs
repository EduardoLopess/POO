using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class MateriaMap : IEntityTypeConfiguration<Materia>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materia");

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