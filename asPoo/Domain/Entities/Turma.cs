namespace Domain.Entities
{
    public class Turma
    {
        public Turma()
        {
            Alunos = new List<Aluno>();
            Professor = new List<Professor>();
        }
        public int Id {get; set;}
        public int Sala {get; set;}
        public int numeroTurma{get; set;}


        //Navegacao
        public List<Aluno> Alunos {get; set;}
    
        public List<Professor> Professor {get; set;}
        public Curso Curso {get; set;}
        public int CursoID {get; set;}
        
    }
}