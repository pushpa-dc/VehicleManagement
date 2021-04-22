using System.Linq;
using System.Threading.Tasks;
using Vega.Data;
using Vega.Models;

namespace VehicleManagement.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Vehicle> GetVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            return vehicle;
        }
    }
}