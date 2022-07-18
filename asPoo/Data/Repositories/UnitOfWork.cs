using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IAlunoRepository _AlunoRepository;
        public IAlunoRepository AlunoRepository
        {
            get
            {
                return _AlunoRepository ??= new AlunoRepository(_context);
            }
        }

        private ICursoRepository _CursoRepository;
        public ICursoRepository CursoRepository
        {
            get
            {
                return _CursoRepository ??= new CursoRepository(_context);
            }
        }
        
        private IDepartamentoRepository _DepartamentoRepository;
        public IDepartamentoRepository DepartamentoRepository 
        {
            get
            {
                return _DepartamentoRepository ??= new DepartamentoRepository(_context);
            }
        }

        private INotaRepository _NotaRepository;
        public INotaRepository NotaRepository
        {
            get
            {
                return _NotaRepository ??= new NotaRepository(_context);
            }
        } 

        private IProfessorRepository _ProfessorRepository;
        public IProfessorRepository ProfessorRepository
        {
            get
            {
                return _ProfessorRepository ??= new ProfessorRepository(_context);
            }
        } 

        private ITurmaRepository _TurmaRepository;
        public ITurmaRepository TurmaRepository
        {
            get
            {
                return _TurmaRepository ??= new TurmaRepository(_context);
            }
        } 

        private IEnderecoRepository _EnderecoReposity;
        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                return _EnderecoReposity ??= new EnderecoRepository(_context);
            }
        } 

        private IMateriaRepository _MateriaRepository;
        public IMateriaRepository MateriaRepository 
        {
            get
            {
                return _MateriaRepository ??= new MateriaRepository(_context);
            }
        }

        //BUGADO
        public IHistoricosRepository HistoricosRepository => throw new NotImplementedException();
    }
}