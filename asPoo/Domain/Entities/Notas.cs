namespace Domain.Entities
{
    public class Notas
    {
        public int Id {get; set;}
        public double Nota {get; set;}
        
        //Navegacao
        public Materia materia {get; set;}
        public int MateriaID {get; set;}
        public Aluno aluno {get; set;}
        public int AlunoID {get; set;}
        // public Historico Historico {get; set;}
        public int HistoricoID {get; set;}
    }
}