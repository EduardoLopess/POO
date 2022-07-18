using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
         private readonly DataContext _context;

        public ProfessorRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Professor> createAsync(Professor entity)
        {
            entity.Endereco = await _context.Enderecos
            .SingleOrDefaultAsync(x => x.Id == entity.Endereco.Id);
            await _context.Professores.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
            var delete = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Professor>> getAsync()
        {
            return await _context.Professores
            .Include(d => d.departamento)   
            .Include(t => t.Turmas)
            .Include(c => c.Curso)
            .Include(e => e.Endereco)
            .Include(m => m.Materias)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Professor> getByIdAsync(int id)
        {
            return await _context.Professores
            .Include(c => c.Curso)
            .Include(t => t.Turmas)
            .Include(m => m.Materias)
            .Include(e => e.Endereco)  
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Professor entity)
        {
           var updateResult = await _context.Professores
            .Include(c => c.Curso)    
            .Include(t => t.Turmas)
            .Include(e => e.Endereco)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();    
        }
    }
}