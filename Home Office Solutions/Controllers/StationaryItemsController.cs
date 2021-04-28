using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home_Office_Solutions.Models;

namespace Home_Office_Solutions.Controllers
{
    public class StationaryItemsController : Controller
    {
        private readonly ShopContext _context;

        public StationaryItemsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        // GET: StationaryItems
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var name = from s in _context.stationaryItems
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                name = name.Where(s => s.Name.Contains(searchString) || s.Color.Contains(searchString) || s.Brand.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    name = name.OrderByDescending(s => s.Name);
                    break;
                default:
                    name = name.OrderBy(s => s.Name);
                    break;
            }

            return View(await name.AsNoTracking().ToListAsync());
        }

        // GET: StationaryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.stationaryItems
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (stationaryItem == null)
            {
                return NotFound();
            }

            return View(stationaryItem);
        }

        // GET: StationaryItems/CheckSuppliers/5
        public async Task<IActionResult> CheckSuppliers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.stationaryItems
                .FirstOrDefaultAsync(m => m.ProductID == id);

            var stationaryItemStock = stationaryItem.Stocks;

            if (stationaryItem == null)
            {
                return NotFound();
            }

            return View(stationaryItemStock);
        }

        // GET: StationaryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StationaryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,ProductType,Brand,Color")] StationaryItem stationaryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stationaryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stationaryItem);
        }

        // GET: StationaryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.stationaryItems.FindAsync(id);
            if (stationaryItem == null)
            {
                return NotFound();
            }
            return View(stationaryItem);
        }

        // POST: StationaryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,ProductType,Brand,Color")] StationaryItem stationaryItem)
        {
            if (id != stationaryItem.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stationaryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationaryItemExists(stationaryItem.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stationaryItem);
        }

        // GET: StationaryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.stationaryItems
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (stationaryItem == null)
            {
                return NotFound();
            }

            return View(stationaryItem);
        }

        // POST: StationaryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stationaryItem = await _context.stationaryItems.FindAsync(id);
            _context.stationaryItems.Remove(stationaryItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationaryItemExists(int id)
        {
            return _context.stationaryItems.Any(e => e.ProductID == id);
        }
    }
}
