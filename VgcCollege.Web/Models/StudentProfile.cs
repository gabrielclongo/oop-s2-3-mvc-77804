using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VgcCollege.Web.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

       
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DOB { get; set; }
        public string? StudentNumber { get; set; }

      
        public string? IdentityUserId { get; set; }
        public IdentityUser? IdentityUser { get; set; }

       
        public ICollection<AssignmentResult>? AssignmentResults { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}