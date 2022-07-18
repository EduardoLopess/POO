using Domain.Entities;

namespace api.ViewModels
{
    public class ProfessorViewPatch
    {
        public string nome {get; set;}
        public string sobreNome {get; set;}
        public int cdgIndentificacao{get; set;}
        public string fone {get; set;}

       
    //     public Departamento Departamento {get; set;}
         public Endereco Endereco {get;set;}
    //     public Turma Turma {get; set;}
    //     public Curso Curso {get; set;}
    }
}