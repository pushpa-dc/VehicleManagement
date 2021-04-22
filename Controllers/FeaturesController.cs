using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vega.Data;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FeaturesController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult GetFeatures()
        {
            var features = _context.Features.ToList();
            return Ok(features);
        }
    }
}