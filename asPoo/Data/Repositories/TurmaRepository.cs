using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
         private readonly DataContext _context;

        public TurmaRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Turma> createAsync(Turma entity)
        {
            entity.Curso = await _context.Cursos
            .SingleOrDefaultAsync(x => x.Id == entity.Curso.Id);
            await _context.Turmas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
             var delete = await _context.Turmas.FindAsync(id);
            _context.Turmas.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Turma>> getAsync()
        {
            return await _context.Turmas
            .Include(c => c.Curso)
            .Include(p => p.Professor)
            .Include(a => a.Alunos)
            .AsNoTracking().ToListAsync();
        }

     

        public async Task<Turma> getByIdAsync(int id)
        {
            return await _context.Turmas
            .Include(c => c.Curso)
            .Include(p => p.Professor)
            .Include(a => a.Alunos)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Turma entity)
        {
            var updateResult = await _context.Turmas
            .Include(c => c.Curso)    
            .Include(p => p.Professor)
            .Include(a => a.Alunos)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();    
        }
    }
}