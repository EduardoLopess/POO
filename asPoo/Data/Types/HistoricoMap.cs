using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class HistoricoMap : IEntityTypeConfiguration<Historico>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Historico> builder)
        {
            // builder.ToTable("Historico");

            //  builder.Property(i => i.Id)
            //     .HasColumnName("id");
            // builder.HasKey(i => i.Id);

            // builder.Property(i => i.PeriodoRealizacao)
            //     .HasColumnName("periodoRealizacao")
            //     .HasColumnType("DATE")
            //     .IsRequired();

            // builder.HasOne(x => x.Aluno)
            //     .WithOne(x => x.historico)
            //     .HasConstraintName("fk_aluno_historico")
            //     .OnDelete(DeleteBehavior.Restrict);

            
              

        }
    }
}