using Domain.Entities;

namespace api.DTOs
{
    public class TurmaDTO
    {
        public int Id {get; set;}
        public int Sala {get; set;}
        public int numeroTurma{get; set;}
        public int CursoID {get; set;}
        public List<Aluno> alunos {get; set;}
        public List<Professor> Professor {get; set;}
    }
}



       