namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IAlunoRepository AlunoRepository{get;}
        ICursoRepository CursoRepository{get;}
        IDepartamentoRepository DepartamentoRepository {get;}
        INotaRepository NotaRepository {get;}
        IProfessorRepository ProfessorRepository {get;}
        ITurmaRepository TurmaRepository {get;}
        IEnderecoRepository EnderecoRepository {get;}
        IMateriaRepository MateriaRepository {get;}
        IHistoricosRepository HistoricosRepository {get;}

    }
}