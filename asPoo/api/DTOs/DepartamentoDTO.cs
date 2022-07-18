using Domain.Entities;

namespace api.DTOs
{
    public class DepartamentoDTO
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public List<Curso> cursos{get; set;}
        public List<Professor> professores {get; set;}
       
    }
}