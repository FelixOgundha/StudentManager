using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        
        [Required]
        public string Name { get; set; } = string.Empty;

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
