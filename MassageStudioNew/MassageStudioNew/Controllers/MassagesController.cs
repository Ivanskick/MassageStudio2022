using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;

namespace MassageStudioApp.Controllers
{
    public class MassagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MassagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Massages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Massages.Include(m => m.Category).Include(m => m.Client).Include(m => m.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Massages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var massage = await _context.Massages
                .Include(m => m.Category)
                .Include(m => m.Client)
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (massage == null)
            {
                return NotFound();
            }

            return View(massage);
        }

        // GET: Massages/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            return View();
        }

        // POST: Massages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ClientId,EmployeeId,CategoryId")] Massage massage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(massage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", massage.CategoryId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName", massage.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", massage.EmployeeId);
            return View(massage);
        }

        // GET: Massages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var massage = await _context.Massages.FindAsync(id);
            if (massage == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", massage.CategoryId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName", massage.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", massage.EmployeeId);
            return View(massage);
        }

        // POST: Massages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ClientId,EmployeeId,CategoryId")] Massage massage)
        {
            if (id != massage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(massage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MassageExists(massage.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", massage.CategoryId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName", massage.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", massage.EmployeeId);
            return View(massage);
        }

        // GET: Massages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var massage = await _context.Massages
                .Include(m => m.Category)
                .Include(m => m.Client)
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (massage == null)
            {
                return NotFound();
            }

            return View(massage);
        }

        // POST: Massages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var massage = await _context.Massages.FindAsync(id);
            _context.Massages.Remove(massage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MassageExists(int id)
        {
            return _context.Massages.Any(e => e.Id == id);
        }
    }
}
