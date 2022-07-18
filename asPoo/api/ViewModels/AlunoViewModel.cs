using Domain.Entities;

namespace api.ViewModels
{
    public class AlunoViewModel
    {
        public string Nome {get; set;}
        public string sobreNome {get; set;}
        public string phone {get; set;}
        public int NumeroMatricula {get; set;}
        public DateTime DtNascimento {get; set;}

        public Endereco Endereco {get;set;}
       
        
    }
}