namespace Domain.Entities
{
    public class Historico
    {
        public Historico()
        {
            Notas = new List<Notas>();
        }
        public int Id {get; set;}
        public DateTime PeriodoRealizacao {get; set;}

        //Navegacao
        public Aluno Aluno {get; set;}
        public int AlunoID {get; set;}
        public List<Notas> Notas {get; set;}
        public Materia materia {get; set;}
        public int MateriaID {get; set;}
             
    }
}