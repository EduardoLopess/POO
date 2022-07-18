using Domain.Entities;

namespace api.ViewModels
{
    public class AlunoViewPatch
    {
        public string Nome {get; set;}
        public string sobreNome {get; set;}
        public string phone {get; set;} 
        public Endereco Endereco {get;set;}
        
       
    }
}