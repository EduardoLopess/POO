using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class HistoricosRepository : IBaseRepository<Historico>
    {
        private readonly DataContext _context;

        public HistoricosRepository(DataContext _context)
        {
            this._context = _context;
        }
        public Task<Historico> createAsync(Historico entity)
        {
            throw new NotImplementedException();
        }

        public Task deleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Historico>> getAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Historico> getByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(Historico entity)
        {
            throw new NotImplementedException();
        }
    }
}