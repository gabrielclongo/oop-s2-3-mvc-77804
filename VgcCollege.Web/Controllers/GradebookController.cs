using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VgcCollege.Web.Data;

namespace VgcCollege.Web.Controllers
{
    [Authorize]
    public class GradebookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradebookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.StudentProfiles
                .Include(s => s.AssignmentResults)
                .Include(s => s.ExamResults)
                .ToListAsync();

            return View(students);
        }
    }
}