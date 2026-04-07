using System.ComponentModel.DataAnnotations;

namespace VgcCollege.Web.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
        public int StudentProfileId { get; set; }
        public StudentProfile? StudentProfile { get; set; }
        public double Score { get; set; }
        public string? Grade { get; set; }
        public string? Feedback { get; set; }
    }
}