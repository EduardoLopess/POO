using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
         private readonly DataContext _context;

        public AlunoRepository(DataContext _context)
        {
            this._context = _context;
        }

        public async Task<Aluno> createAsync(Aluno entity)
        {
            entity.Endereco = await _context.Enderecos
            .SingleOrDefaultAsync(x => x.Id == entity.Endereco.Id);
            await _context.Alunos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
            var delete = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aluno>> getAsync()
        {
            return await _context.Alunos
            .Include(c => c.Curso)   
            .Include(n => n.Notas)
            .Include(t => t.Turma)
            .Include(m => m.Materias)
            .Include(e => e.Endereco)
            .AsNoTracking().ToListAsync();    
        }

        public async Task<Aluno> getByIdAsync(int id)
        {
            return await _context.Alunos
            .Include(c => c.Curso)
            .Include(t => t.Turma)
            .Include(m => m.Materias)
            .Include(n => n.Notas)
            .Include(e => e.Endereco)  
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Aluno entity)
        {
            var updateResult = await _context.Alunos
            .Include(c => c.Curso)    
            .Include(n => n.Notas)
            .Include(t => t.Turma)
            .Include(e => e.Endereco)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();    
        }
    }
}