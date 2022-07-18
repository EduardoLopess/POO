using Domain.Entities;

namespace api.DTOs
{
    public class CursoDTO
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public DateTime Duracao {get; set;}
        public Departamento Departamento {get; set;}
        
    }
}