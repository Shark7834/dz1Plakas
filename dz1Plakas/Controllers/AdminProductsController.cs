using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dz1Plakas.Data;
using dz1Plakas.Models;

namespace dz1Plakas.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/MyWay")]
        public string MyWay()
        {
            return "Hello Annotation";
        }

        [Route("/MyWay2")]
        public async Task<IActionResult> MyWay2()
        {
            return  Content("Async Annotation");
        }

        [Route("/MyWay3")]
        public IActionResult MyWay3()
        {
            return Content("Annotation3");
        }


        // GET: AdminProducts
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.products.Include(p=>p.brend).ToListAsync());
        }

        public async Task<IActionResult> byBrend(String name,int id)
        {

            return View(await _context.products
                .Where(p => p.brend.id == id)
                .Include(p => p.brend)
                .ToListAsync());
            
        }

        // GET: AdminProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var product = await _context.products
            //    .FirstOrDefaultAsync(m => m.id == id);
            Product product = _context.products
                .Single(p => p.id == id);
            _context.Entry(product).Reference(p => p.brend).Load();

          

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: AdminProducts/Create
        public IActionResult Create()

        {
            ViewBag.brends = _context.brends;
            ViewBag.colors = _context.colors;
            return View();
        }

        // POST: AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Product product,
            int brendid,
            int?[] colorsid)
        {
            if (ModelState.IsValid)
            {

                product.brend = _context.brends.Find(brendid);

                _context.Add(product);
                await _context.SaveChangesAsync();

                

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: AdminProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            return View(product);
        }

        // GET: AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.id == id);
        }
    }
}
