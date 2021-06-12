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
    public class CarColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarColors
        public async Task<IActionResult> Index()
        {
            return View(await _context.carColor.ToListAsync());
        }

        // GET: CarColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carColor = await _context.carColor
                .FirstOrDefaultAsync(m => m.id == id);
            if (carColor == null)
            {
                return NotFound();
            }

            return View(carColor);
        }

        // GET: CarColors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,rgb,url")] CarColor carColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carColor);
        }

        // GET: CarColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carColor = await _context.carColor.FindAsync(id);
            if (carColor == null)
            {
                return NotFound();
            }
            return View(carColor);
        }

        // POST: CarColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,rgb,url")] CarColor carColor)
        {
            if (id != carColor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarColorExists(carColor.id))
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
            return View(carColor);
        }

        // GET: CarColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carColor = await _context.carColor
                .FirstOrDefaultAsync(m => m.id == id);
            if (carColor == null)
            {
                return NotFound();
            }

            return View(carColor);
        }

        // POST: CarColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carColor = await _context.carColor.FindAsync(id);
            _context.carColor.Remove(carColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarColorExists(int id)
        {
            return _context.carColor.Any(e => e.id == id);
        }
    }
}
