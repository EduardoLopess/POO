namespace Domain.Entities
{
    public class Endereco
    {
        public int Id {get; set;}
        public int CEP {get; set;}
        public string Rua {get; set;}
        public string Cidade {get; set;}
        public int numCasa {get; set;}
        public string Complemento {get; set;}

        //Navegacao
        public Aluno Alunos {get; set;}
        public int AlunoID {get; set;}
        public Professor Professores {get; set;}
        public int ProfesssorID {get; set;}
        
        
    }
}