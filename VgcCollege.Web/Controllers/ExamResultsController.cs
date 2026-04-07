using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VgcCollege.Web.Data;
using VgcCollege.Web.Models;

namespace VgcCollege.Web.Controllers
{
    [Authorize]
    public class ExamResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = _context.ExamResults
                .Include(e => e.StudentProfile)
                .Include(e => e.Exam);

            return View(await data.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["StudentProfileId"] = new SelectList(_context.StudentProfiles, "Id", "Name");
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamResult result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudentProfileId"] = new SelectList(_context.StudentProfiles, "Id", "Name", result.StudentProfileId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Title", result.ExamId);
            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _context.ExamResults.FindAsync(id);
            if (result == null) return NotFound();

            ViewData["StudentProfileId"] = new SelectList(_context.StudentProfiles, "Id", "Name", result.StudentProfileId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Title", result.ExamId);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamResult result)
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
            var result = await _context.ExamResults
                .Include(e => e.StudentProfile)
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (result == null) return NotFound();

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _context.ExamResults.FindAsync(id);

            if (result != null)
            {
                _context.ExamResults.Remove(result);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}