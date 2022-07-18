using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext _context;

        public EnderecoRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<Endereco> createAsync(Endereco entity)
        {
            entity.Alunos = await _context.Alunos
            .SingleOrDefaultAsync(x => x.Id == entity.Alunos.Id);
            entity.Professores = await _context.Professores
            .SingleOrDefaultAsync(x => x.Id == entity.Professores.Id);
            await _context.Enderecos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task deleteAsync(int id)
        {
             var delete = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Endereco>> getAsync()
        {
            return await _context.Enderecos
            .Include(p => p.Professores)
            .Include(a => a.Alunos)
            .AsNoTracking().ToListAsync();
        }

        public async Task<Endereco> getByIdAsync(int id)
        {
            return await _context.Enderecos
            .Include(p => p.Professores)
            .Include(a => a.Alunos)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(Endereco entity)
        {
           var updateResult = await _context.Enderecos
            .Include(p => p.Professores)
            .Include(a => a.Alunos)
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Entry(updateResult).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();    
        }
    }
}