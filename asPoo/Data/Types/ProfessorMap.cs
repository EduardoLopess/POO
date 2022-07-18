using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");

            builder.Property(i => i.Id)
                .HasColumnName("id");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.nome)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(i => i.sobreNome)
                .HasColumnName("sobreNome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();
            
            builder.Property(i => i.fone)
                .HasColumnName("fone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(12)
                .IsRequired();    

            builder.Property(i => i.cdgIndentificacao)
                .HasColumnName("cdgIndentificacao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

        }
    }
}