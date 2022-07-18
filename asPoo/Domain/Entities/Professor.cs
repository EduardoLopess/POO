namespace Domain.Entities
{
    public class Professor
    {
        public Professor()
        {
            Materias = new List<Materia>();
        }
        public int Id {get; set;}
        public string nome {get; set;}
        public string sobreNome {get; set;}
        public int cdgIndentificacao{get; set;}
        public string fone {get; set;}

        //navegacao
        public Endereco Endereco {get; set;}
        public int EnderecoID {get; set;}
        public Turma Turmas {get; set;}
        public Curso Curso {get; set;}
        public int CursoID {get; set;}
        public List<Materia> Materias {get; set;}
        public Departamento departamento {get; set;}
        public int DepartamentoID {get; set;}
        

    }
}