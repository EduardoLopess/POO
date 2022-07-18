using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.Property(i => i.Id)
                .HasColumnName("id");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Rua)
                .HasColumnName("rua")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(i => i.CEP)
                .HasColumnName("cep")
                .HasColumnType("INT")
                .HasMaxLength(15)
                .IsRequired();
                
            builder.Property(i => i.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(i => i.numCasa)
                .HasColumnName("numCasa")
                .HasColumnType("INT")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(i => i.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .IsRequired();

                              
        }
    }
}