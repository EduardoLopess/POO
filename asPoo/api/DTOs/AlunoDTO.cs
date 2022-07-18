using Domain.Entities;
namespace api.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome {get; set;}
        public string sobreNome {get; set;}
        public string phone {get; set;}
        public int NumeroMatricula {get; set;}
        public DateTime DtNascimento {get; set;}

        public Endereco Endereco {get;set;}
       
    }
}