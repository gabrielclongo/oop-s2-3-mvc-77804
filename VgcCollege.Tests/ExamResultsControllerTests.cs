using Xunit;
using Microsoft.EntityFrameworkCore;
using VgcCollege.Web.Data;
using VgcCollege.Web.Controllers;
using VgcCollege.Web.Models;
using System.Threading.Tasks;
using System.Linq;

namespace VgcCollege.Tests
{
    public class ExamResultsControllerTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ExamResultsDB") 
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Create_ExamResult_ShouldSave()
        {
            var context = CreateContext();

            var student = new StudentProfile { Name = "Test Student" };
            var exam = new Exam { Title = "Test Exam" };

            context.StudentProfiles.Add(student);
            context.Exams.Add(exam);
            await context.SaveChangesAsync();

            var controller = new ExamResultsController(context);

            var result = new ExamResult
            {
                StudentProfileId = student.Id,
                ExamId = exam.Id,
                Score = 90,
                Feedback = "Good"
            };

            await controller.Create(result);

            Assert.Equal(1, context.ExamResults.Count());
        }
    }
}