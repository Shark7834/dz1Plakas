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
    public class CarMarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarMarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarMarks
        public async Task<IActionResult> Index()
        {
            return View(await _context.carMark.ToListAsync());
        }

        // GET: CarMarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMark = await _context.carMark
                .FirstOrDefaultAsync(m => m.id == id);
            if (carMark == null)
            {
                return NotFound();
            }

            return View(carMark);
        }

        // GET: CarMarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarMarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,url")] CarMark carMark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carMark);
        }

        // GET: CarMarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMark = await _context.carMark.FindAsync(id);
            if (carMark == null)
            {
                return NotFound();
            }
            return View(carMark);
        }

        // POST: CarMarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,url")] CarMark carMark)
        {
            if (id != carMark.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carMark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarMarkExists(carMark.id))
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
            return View(carMark);
        }

        // GET: CarMarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMark = await _context.carMark
                .FirstOrDefaultAsync(m => m.id == id);
            if (carMark == null)
            {
                return NotFound();
            }

            return View(carMark);
        }

        // POST: CarMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carMark = await _context.carMark.FindAsync(id);
            _context.carMark.Remove(carMark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarMarkExists(int id)
        {
            return _context.carMark.Any(e => e.id == id);
        }
    }
}
