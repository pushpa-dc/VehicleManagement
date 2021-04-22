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
    public class MakesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MakesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetMakesAsync()
        {
            var makes = await _context.Makes.Include(m=>m.Models).ToListAsync();
            return Ok(makes);
        }
    }
}