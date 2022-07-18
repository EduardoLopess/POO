using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class NotaMap : IEntityTypeConfiguration<Notas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Notas> builder)
        {
            builder.ToTable("Notas");

            builder.Property(i => i.Id)
                .HasColumnName("id");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nota)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

           
        }
    }
}