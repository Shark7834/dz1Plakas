using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dz1Plakas.Data;
using dz1Plakas.Models;
using Microsoft.AspNetCore.Authorization;

namespace dz1Plakas.Controllers
{
   
    public class AdminPagesController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public AdminPagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.pages.ToListAsync());
        }

        // GET: AdminPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.pages
                .FirstOrDefaultAsync(m => m.id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: AdminPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,body,seokey,seods,ing")] Page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: AdminPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: AdminPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,body,seokey,seods,ing")] Page page)
        {
            if (id != page.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.id))
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
            return View(page);
        }

        // GET: AdminPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.pages
                .FirstOrDefaultAsync(m => m.id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: AdminPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.pages.FindAsync(id);
            _context.pages.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _context.pages.Any(e => e.id == id);
        }
    }
}
