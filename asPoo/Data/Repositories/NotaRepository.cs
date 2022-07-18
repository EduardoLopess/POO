using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
         private readonly DataContext _context;

        public NotaRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Notas> createAsync(Notas entity)
        {
            entity.aluno = await _context.Alunos
            .SingleOrDefaultAsync(x => x.Id == entity.aluno.Id && x.Id == entity.materia.Id);
            await _context.Notas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task deleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Notas>> getAsync()
        {
            return await _context.Notas
            .Include(m => m.materia)
            .Include(a => a.aluno)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Notas> getByIdAsync(int id)
        {
            return await _context.Notas
            .Include(m => m.materia)
            .Include(a => a.aluno)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        
        public async Task updateAsync(Notas entity)
        {
            var updateResult = await _context.Notas
            .Include(m => m.materia)
            .Include(a => a.aluno)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();    
        }
    }
}