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
    public class HoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hours
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hour.Include(h => h.Employee).Include(h => h.Reservation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hour = await _context.Hour
                .Include(h => h.Employee)
                .Include(h => h.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hour == null)
            {
                return NotFound();
            }

            return View(hour);
        }

        // GET: Hours/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "Id", "Id");
            return View();
        }

        // POST: Hours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FreeHour,IsDeleted,EmployeeId,ReservationId")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", hour.EmployeeId);
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "Id", "Id", hour.ReservationId);
            return View(hour);
        }

        // GET: Hours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hour = await _context.Hour.FindAsync(id);
            if (hour == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", hour.EmployeeId);
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "Id", "Id", hour.ReservationId);
            return View(hour);
        }

        // POST: Hours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FreeHour,IsDeleted,EmployeeId,ReservationId")] Hour hour)
        {
            if (id != hour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HourExists(hour.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", hour.EmployeeId);
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "Id", "Id", hour.ReservationId);
            return View(hour);
        }

        // GET: Hours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hour = await _context.Hour
                .Include(h => h.Employee)
                .Include(h => h.Reservation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hour == null)
            {
                return NotFound();
            }

            return View(hour);
        }

        // POST: Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hour = await _context.Hour.FindAsync(id);
            _context.Hour.Remove(hour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HourExists(int id)
        {
            return _context.Hour.Any(e => e.Id == id);
        }
    }
}
