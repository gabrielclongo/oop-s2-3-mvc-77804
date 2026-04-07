using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VgcCollege.Web.Data;
using VgcCollege.Web.Models;

namespace VgcCollege.Web.Controllers
{
    [Authorize]
    public class AssignmentResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = _context.AssignmentResults
                .Include(a => a.StudentProfile)
                .Include(a => a.Assignment);

            return View(await data.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["StudentProfileId"] = new SelectList(_context.StudentProfiles, "Id", "Name");
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssignmentResult result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudentProfileId"] = new SelectList(_context.StudentProfiles, "Id", "Name", result.StudentProfileId);
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title", result.AssignmentId);
            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _context.AssignmentResults.FindAsync(id);
            if (result == null) return NotFound();

            ViewData["StudentProfileId"] = new SelectList(_context.StudentProfiles, "Id", "Name", result.StudentProfileId);
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Title", result.AssignmentId);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssignmentResult result)
        {
            if (id != result.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.AssignmentResults
                .Include(a => a.StudentProfile)
                .Include(a => a.Assignment)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _context.AssignmentResults.FindAsync(id);

            if (result != null)
            {
                _context.AssignmentResults.Remove(result);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}