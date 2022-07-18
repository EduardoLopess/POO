namespace Domain.Entities
{
    public class Aluno
    {
        public Aluno()
        {
            Materias = new List<Materia>();
            Notas = new List<Notas>();

        }
 
        public int Id { get; set; }
        public string Nome {get; set;}
        public string sobreNome {get; set;}
        public string phone {get; set;}
        public int NumeroMatricula {get; set;}
        public DateTime DtNascimento {get; set;}

        //Navegacao
        public Endereco Endereco {get; set;}
        public Turma Turma {get; set;}
        public Curso Curso {get; set;}
        public List<Materia> Materias {get; set;}
        public List<Notas> Notas {get; set;}
        // public Historico historico {get; set;}
        
    }
}