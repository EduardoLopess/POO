using Domain.Entities;

namespace api.DTOs
{
    public class ProfessorDTO
    {
        public int Id {get; set;}
        public string nome {get; set;}
        public string sobreNome {get; set;}
        public int cdgIndentificacao{get; set;}
        public string fone {get; set;}

       
        public Endereco Endereco {get;set;}
    
    
    }
}