using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.Models;

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