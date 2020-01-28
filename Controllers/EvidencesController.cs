using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghost.Data;
using Ghost.Models;

namespace Ghost.Controllers
{
    public class EvidencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvidencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evidences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Evidence.Include(e => e.Investigation).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evidences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidence = await _context.Evidence
                .Include(e => e.Investigation)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evidence == null)
            {
                return NotFound();
            }

            return View(evidence);
        }

        // GET: Evidences/Create
        public IActionResult Create()
        {
            ViewData["InvestigationId"] = new SelectList(_context.Investigation, "Id", "Summary");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Evidences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Date,Summary,MyAudio,MyVideo,InvestigationId,UserId")] Evidence evidence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evidence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvestigationId"] = new SelectList(_context.Investigation, "Id", "Summary", evidence.InvestigationId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", evidence.UserId);
            return View(evidence);
        }

        // GET: Evidences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidence = await _context.Evidence.FindAsync(id);
            if (evidence == null)
            {
                return NotFound();
            }
            ViewData["InvestigationId"] = new SelectList(_context.Investigation, "Id", "Summary", evidence.InvestigationId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", evidence.UserId);
            return View(evidence);
        }

        // POST: Evidences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Date,Summary,MyAudio,MyVideo,InvestigationId,UserId")] Evidence evidence)
        {
            if (id != evidence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evidence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvidenceExists(evidence.Id))
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
            ViewData["InvestigationId"] = new SelectList(_context.Investigation, "Id", "Summary", evidence.InvestigationId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", evidence.UserId);
            return View(evidence);
        }

        // GET: Evidences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidence = await _context.Evidence
                .Include(e => e.Investigation)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evidence == null)
            {
                return NotFound();
            }

            return View(evidence);
        }

        // POST: Evidences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evidence = await _context.Evidence.FindAsync(id);
            _context.Evidence.Remove(evidence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvidenceExists(int id)
        {
            return _context.Evidence.Any(e => e.Id == id);
        }
    }
}
