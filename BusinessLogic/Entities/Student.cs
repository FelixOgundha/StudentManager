using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        public string StudentName { get; set; } = string.Empty;

        [EmailAddress]
        public string StudentEmail { get; set; } = string.Empty;

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }

        public Course? Course { get; set; }
    }
}
