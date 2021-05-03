using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home_Office_Solutions.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagedList;

namespace Home_Office_Solutions.Controllers
{
    public class StocksController : Controller
    {
        private readonly ShopContext _context;

        

        public StocksController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        private IEnumerable<StockShopAddress> StockShoplist
        {
            get => from s in _context.stocks
                   join st in _context.stationaryItems
                   on s.ProductID equals st.ProductID
                   join sh in _context.Shops
                   on s.ShopID equals sh.ShopID
                   select new StockShopAddress { Name = st.Name, ProductID = st.ProductID, ShopName = sh.ShopName, ShopID = sh.ShopID, ShopAddress = sh.ShopAddress, Price = s.Price, StockID = s.StockID };
        }
        // GET: Stocks
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            

            ViewData["CurrentFilter"] = searchString;

            var stocks = from s in StockShoplist
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stocks = stocks.Where(s => s.Name.Contains(searchString) || s.ShopName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    stocks = stocks.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    stocks = stocks.OrderBy(s => s.Price);
                    break;
                default:
                    stocks = stocks.OrderBy(s => s.Name);
                    break;

            }


            return View(stocks.ToList());
/*
            var shopContext = _context.stocks.Include(s => s.Shop);
            return View(await shopContext.ToListAsync());*/
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }
            if (pd == null)
            {
                return NotFound();
            }
            if (st == null)
            {
                return NotFound();
            }*/

            StockShopAddress ssfound = StockShoplist.FirstOrDefault(p => p.ProductID == id);

            var stock = await _context.stocks
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.StockID == id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["ShopID"] = new SelectList(_context.Shops, "ShopID", "ShopAddress");
            ViewData["ProductID"] = new SelectList(_context.stationaryItems, "ProductID", "Name");
            /*Shop foundShop = _context.Shops.FirstOrDefault(p => p.ShopID == id);
            StationaryItem foundItem = _context.stationaryItems.FirstOrDefault(p => p.ProductID == pd);
            Stock foundStock = _context.stocks.FirstOrDefault(p => p.StockID == st);
            ViewModel vm1 = new ViewModel() { Shop = foundShop, StationaryItem = foundItem, Stock = foundStock};*/
           
            return View(ssfound);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {

            ViewData["ShopID"] = new SelectList(_context.Shops, "ShopID", "ShopAddress");
            ViewData["ProductID"] = new SelectList(_context.stationaryItems, "ProductID", "Name");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockID,ProductID,ShopID,Price")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopID"] = new SelectList(_context.Shops, "ShopID", "ShopAddress", stock.ShopID);
            ViewData["ProductID"] = new SelectList(_context.stationaryItems, "ProductID", "Name", stock.ProductID);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["ShopID"] = new SelectList(_context.Shops, "ShopID", "ShopAddress", stock.ShopID);
            ViewData["ProductID"] = new SelectList(_context.stationaryItems, "ProductID", "Name", stock.ProductID);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockID,ProductID,ShopID,Price")] Stock stock)
        {
            if (id != stock.StockID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockID))
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
            ViewData["ShopID"] = new SelectList(_context.Shops, "ShopID", "ShopAddress", stock.ShopID);
            ViewData["ProductID"] = new SelectList(_context.stationaryItems, "ProductID", "Name", stock.ProductID);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.stocks
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.StockID == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _context.stocks.FindAsync(id);
            _context.stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _context.stocks.Any(e => e.StockID == id);
        }
    }
}
