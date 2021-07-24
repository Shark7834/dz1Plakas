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
    public class ContactFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Txk()
        {
            return View();
        }

        // GET: ContactForms/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("id,name,email,phone")] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactForm);
                await _context.SaveChangesAsync();
                //todo - метод сообщить менеджерам о новой заявке


                return RedirectToAction(nameof(Txk));
            }
            return View(contactForm);
        }

       
    }
}
