using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Data;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MakesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetMakesAsync()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            return Ok(makes);
        }
    }
}