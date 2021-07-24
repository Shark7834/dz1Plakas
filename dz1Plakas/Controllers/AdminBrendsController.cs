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
    public class AdminBrendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminBrendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminBrends
        public async Task<IActionResult> Index()
        {
            return View(await _context.brends.ToListAsync());
        }

        // GET: AdminBrends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brend = await _context.brends
                .FirstOrDefaultAsync(m => m.id == id);
            if (brend == null)
            {
                return NotFound();
            }

            return View(brend);
        }

        // GET: AdminBrends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminBrends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Brend brend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brend);
        }

        // GET: AdminBrends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brend = await _context.brends.FindAsync(id);
            if (brend == null)
            {
                return NotFound();
            }
            return View(brend);
        }

        // POST: AdminBrends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Brend brend)
        {
            if (id != brend.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrendExists(brend.id))
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
            return View(brend);
        }

        // GET: AdminBrends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brend = await _context.brends
                .FirstOrDefaultAsync(m => m.id == id);
            if (brend == null)
            {
                return NotFound();
            }

            return View(brend);
        }

        // POST: AdminBrends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brend = await _context.brends.FindAsync(id);
            _context.brends.Remove(brend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrendExists(int id)
        {
            return _context.brends.Any(e => e.id == id);
        }
    }
}
