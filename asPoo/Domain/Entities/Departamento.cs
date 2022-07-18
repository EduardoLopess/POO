namespace Domain.Entities
{
    public class Departamento
    {
        public Departamento()
        {
            professores = new List<Professor>();
            cursos = new List<Curso>();
        }

        public int Id {get; set;}
        public string Nome {get; set;}

        //navegacao
        public List<Professor> professores {get; set;}
        public List<Curso> cursos {get; set;}

      
    }
}