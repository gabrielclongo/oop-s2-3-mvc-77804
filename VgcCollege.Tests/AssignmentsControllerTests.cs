using Xunit;
using Microsoft.EntityFrameworkCore;
using VgcCollege.Web.Data;
using VgcCollege.Web.Controllers;
using VgcCollege.Web.Models;
using System.Threading.Tasks;
using System.Linq;

namespace VgcCollege.Tests
{
    public class AssignmentsControllerTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("AssignmentsDB") 
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Create_Assignment_ShouldSave()
        {
            var context = CreateContext();

            var course = new Course { Name = "Test Course" };
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            var controller = new AssignmentsController(context);

            var assignment = new Assignment
            {
                Title = "Test",
                CourseId = course.Id,
                MaxScore = 100
            };

            await controller.Create(assignment);

            Assert.Equal(1, context.Assignments.Count());
        }
    }
}