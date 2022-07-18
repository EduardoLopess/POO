namespace Domain.Entities
{
    public class Materia
    {
        public Materia()
        {
            Alunos = new List<Aluno>();
            notas = new List<Notas>();
            
        }
        public int Id {get; set;}
        public string Nome {get; set;}
        public DateTime Duracao {get; set;}


        //navegacao
        public Curso curso {get; set;}
        public int CursoID {get; set;}
        public Professor professor {get; set;}
        public int ProfesssorID {get; set;}  
        public List<Aluno> Alunos {get; set;}
        public List<Notas> notas {get; set;}
    
        // public Historico Historico {get; set;}
        // public int HistoricoID {get; set;}

    }
}