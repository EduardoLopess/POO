using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Professor> Professores {get; set;}
        public DbSet<Endereco> Enderecos {get; set;}
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Materia> Materias {get; set;}
        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<Turma> Turmas {get; set;}
        public DbSet<Notas> Notas {get; set;}
        public DbSet<Historico> Historicos {get; set;} // Bugada

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new HistoricoMap()); 
        }
    }
}