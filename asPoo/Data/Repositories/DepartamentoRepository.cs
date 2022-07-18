using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
         private readonly DataContext _context;

        public DepartamentoRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Departamento> createAsync(Departamento entity)
        {
            await _context.Departamentos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
             var delete = await _context.Departamentos.FindAsync(id);
            _context.Departamentos.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Departamento>> getAsync()
        {
            return await _context.Departamentos
            .Include(c => c.cursos)
            .Include(p => p.professores)
            .AsNoTracking().ToListAsync();   
        }

        public async Task<Departamento> getByIdAsync(int id)
        {
            return await _context.Departamentos
            .Include(c => c.cursos)
            .Include(p => p.professores)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Departamento entity)
        {
            var updateResult = await _context.Departamentos
            .Include(c => c.cursos)    
            .Include(p => p.professores)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
           
        }
    }
}