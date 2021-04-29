using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Home_Office_Solutions.Models;

namespace Home_Office_Solutions.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationaryItemsAPIController : ControllerBase
    {
        private ShopContext _context = new ShopContext();

        // GET: api/StationaryItemsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationaryItem>>> GetstationaryItems()
        {
            if (_context.stationaryItems.Count() == 0)
            {
                return NotFound();
            }

            else
            {
                return await _context.stationaryItems.ToListAsync();  
            }

        }

        private bool StationaryItemExists(int id)
        {
            return _context.stationaryItems.Any(e => e.ProductID == id);
        }
    }
}
