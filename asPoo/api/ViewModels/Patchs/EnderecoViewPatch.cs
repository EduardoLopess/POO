using Domain.Entities;

namespace api.ViewModels.Patchs
{
    public class EnderecoViewPatch
    {
         public int CEP {get; set;}
        public string Rua {get; set;}
        public string Cidade {get; set;}
        public int numCasa {get; set;}
        public string Complemento {get; set;}

        public int AlunoID {get; set;}
        public int ProfessorID {get; set;}

    }
}