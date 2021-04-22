using System.Threading.Tasks;
using Vega.Models;

namespace VehicleManagement.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id);
    }
}