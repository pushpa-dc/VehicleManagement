using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Data;
using Vega.Models;
using Vega.Persistence;
using VehicleManagement.Persistence;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesController(IMapper mapper, ApplicationDbContext context, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            this.context = context;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            _repository.Add(vehicle);
            await _unitOfWork.CompleteAsync();

            vehicle = await _repository.GetVehicleAsync(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleAsync(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

    
            var vehicle = await _repository.GetVehicleAsync(id);
            if (vehicle == null)
                return NotFound();


            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            await _unitOfWork.CompleteAsync();
            vehicle = await _repository.GetVehicleAsync(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            var vehicle = await _repository.GetVehicleAsync(id, includeRelated: false);
            if (vehicle == null)
                return NotFound();
            context.Remove(vehicle);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }

        public async Task<IActionResult> GetVehiclesAsync()
        {
            var vehicles = await context.Vehicles
        .Include(v => v.Model)
          .ThenInclude(m => m.Make)
          .Include(f => f.Features)
          .ThenInclude(f => f.Feature)
        .ToListAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleAsync(int id)
        {
            var vehicle = await _repository.GetVehicleAsync(id);
            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
    }
}