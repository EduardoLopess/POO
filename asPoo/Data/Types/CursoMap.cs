using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");

            builder.Property(i => i.Id)
                .HasColumnName("id");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60)
                .IsRequired();

           
            builder.HasOne(x => x.Departamento)
                .WithMany(x => x.cursos)
                .HasConstraintName("FK_Departamento_Curso")
                .OnDelete(DeleteBehavior.Restrict);

               
         
                    
                   
        }
    }
}