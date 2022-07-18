using Domain.Entities;

namespace api.DTOs
{
    public class MateriaDTO
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public DateTime Duracao{get; set;}
       

        public Professor Professor{get; set;}
        public Curso Curso {get; set;}
        public List<Notas> notas {get; set;}
    }
}
