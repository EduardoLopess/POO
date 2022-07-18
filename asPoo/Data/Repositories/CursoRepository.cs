using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
         private readonly DataContext _context;

        public CursoRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Curso> createAsync(Curso entity)
        {
            entity.Departamento = await _context.Departamentos
            .SingleOrDefaultAsync(x => x.Id == entity.Departamento.Id);
            await _context.Cursos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
            var delete = await _context.Cursos.FindAsync(id);
            _context.Cursos.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Curso>> getAsync()
        {
            return await _context.Cursos
            .Include(d => d.Departamento)   
            .Include(t => t.Turmas)
            .Include(p => p.Professores)
            .Include(a => a.Alunos)
            .Include(m => m.Materias)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Curso> getByIdAsync(int id)
        {
            return await _context.Cursos
            .Include(d => d.Departamento)   
            .Include(t => t.Turmas)
            .Include(p => p.Professores)
            .Include(a => a.Alunos)
            .Include(m => m.Materias)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Curso entity)
        {
            var updateResult = await _context.Cursos
            .Include(d => d.Departamento)
            .Include(m => m.Materias)
            .Include(p => p.Professores)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();   
        }
    }
}