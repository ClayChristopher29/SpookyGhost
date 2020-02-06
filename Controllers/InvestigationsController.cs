using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghost.Data;
using Ghost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Ghost.Controllers
{
    public class InvestigationsController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;
        

        public InvestigationsController(ApplicationDbContext context,UserManager<ApplicationUser>userManager)
        {
            _userManager=userManager;
            _context = context;
        }
        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Investigations
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            List<Investigation> investigations = await _context.Investigation.Include(i => i.Evidence).Include(i=>i.Location).Where(i => i.User == currentUser).ToListAsync();
           
            return View(investigations);
        }

        // GET: Investigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();

            var investigation = await _context.Investigation
                .Where(i=>i.UserId==user.Id)
                .Include(i => i.Location)
                .FirstOrDefaultAsync(i => i.Id == id && i.User==user);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // GET: Investigations/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Name");
            return View();
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Summary,isPrivate,LocationId,UserId")] Investigation investigation)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                investigation.UserId = currentUser.Id;
                _context.Add(investigation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                

      
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Summary",investigation.LocationId);
            return View(investigation);
        }

        // GET: Investigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.Investigation.FindAsync(id);
            if (investigation == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Summary", investigation.LocationId);
            return View(investigation);
        }

        // POST: Investigations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Summary,isPrivate,LocationId")] Investigation investigation)
        {
            if (id != investigation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await GetCurrentUserAsync();
                    investigation.UserId = currentUser.Id;
                    _context.Update(investigation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestigationExists(investigation.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Summary", investigation.LocationId);
            return View(investigation);
        }

        // GET: Investigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.Investigation
                .Include(i => i.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // POST: Investigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigation = await _context.Investigation.FindAsync(id);
            _context.Investigation.Remove(investigation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestigationExists(int id)
        {
            return _context.Investigation.Any(e => e.Id == id);
        }
    }
}
