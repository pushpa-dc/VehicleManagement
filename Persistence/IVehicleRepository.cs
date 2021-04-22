using System.Threading.Tasks;
using Vega.Models;

namespace VehicleManagement.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true);
        public void Add(Vehicle vehicle);

        public void Remove(Vehicle vehicle);
    }
}