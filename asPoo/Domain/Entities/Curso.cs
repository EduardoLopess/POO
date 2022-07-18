namespace Domain.Entities
{
    public class Curso
    {
        public Curso()
        {
            Materias = new List<Materia>();
            Turmas = new List<Turma>();
            Alunos = new List<Aluno>();
            Professores = new List<Professor>();
        }
        public int Id {get; set;}
        public string Nome {get; set;}
        public DateTime Duracao {get; set;}
        
       
        //navegacao 
        public List<Materia> Materias {get; set;}
        public List<Turma> Turmas {get; set;}
        public List<Professor> Professores {get; set;}  
        public List<Aluno> Alunos {get; set;}
        public Departamento Departamento {get; set;}
        

    }
}