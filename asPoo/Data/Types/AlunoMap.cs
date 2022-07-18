using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Types
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("ALuno");

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(i => i.sobreNome)
                .HasColumnName("sobreNome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(i => i.phone)
                .HasColumnName("phone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(i => i.NumeroMatricula)
                .HasColumnName("numeroMatricula")
                .HasColumnType("INT")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(i => i.DtNascimento)
                .HasColumnName("dataNascimento")
                .HasColumnType("DATE")
                .IsRequired();


        
                              
        }
    }
}