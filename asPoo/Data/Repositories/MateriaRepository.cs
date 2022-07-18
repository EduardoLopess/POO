using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
         private readonly DataContext _context;

        public MateriaRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Materia> createAsync(Materia entity)
        {
             entity.curso = await _context.Cursos
            .SingleOrDefaultAsync(x => x.Id == entity.curso.Id);
            await _context.Materias.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
             var delete = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Materia>> getAsync()
        {
            return await _context.Materias
            .Include(c => c.curso)
            .Include(p => p.professor)
            .AsNoTracking().ToListAsync();  
            
        }

        public async Task<Materia> getByIdAsync(int id)
        {
            return await _context.Materias
            .Include(c => c.curso)
            .Include(p => p.professor)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Materia entity)
        {
            var updateResult = await _context.Materias
            .Include(c => c.curso)
            .Include(p => p.professor)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();    
        }
    }
}