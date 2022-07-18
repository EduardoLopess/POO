using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");

            builder.Property(i => i.Id)
                .HasColumnName("id");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Sala)
                .HasColumnName("sala")
                .HasColumnType("INT")
                .HasMaxLength(10)
                .IsRequired();

        }
    }
}