using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SEsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SEsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SEs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SE.Include(s => s.Exercise).Include(s => s.Session);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SE == null)
            {
                return NotFound();
            }

            var sE = await _context.SE
                .Include(s => s.Exercise)
                .Include(s => s.Session)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sE == null)
            {
                return NotFound();
            }

            return View(sE);
        }

        // GET: SEs/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name");
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "DateTimeStart");
            return View();
        }

        // POST: SEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Weight,NumOfSeries,NumOfReps,ExerciseId,SessionId")] SE sE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", sE.ExerciseId);
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "DateTimeStart", sE.SessionId);
            return View(sE);
        }

        // GET: SEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SE == null)
            {
                return NotFound();
            }

            var sE = await _context.SE.FindAsync(id);
            if (sE == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", sE.ExerciseId);
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "DateTimeStart", sE.SessionId);
            return View(sE);
        }

        // POST: SEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Weight,NumOfSeries,NumOfReps,ExerciseId,SessionId")] SE sE)
        {
            if (id != sE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SEExists(sE.Id))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", sE.ExerciseId);
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "DateTimeStart", sE.SessionId);
            return View(sE);
        }

        // GET: SEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SE == null)
            {
                return NotFound();
            }

            var sE = await _context.SE
                .Include(s => s.Exercise)
                .Include(s => s.Session)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sE == null)
            {
                return NotFound();
            }

            return View(sE);
        }

        // POST: SEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SE == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SE'  is null.");
            }
            var sE = await _context.SE.FindAsync(id);
            if (sE != null)
            {
                _context.SE.Remove(sE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SEExists(int id)
        {
          return _context.SE.Any(e => e.Id == id);
        }
    }
}
