using System.Threading.Tasks;
using Vega.Data;

namespace Vega.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}