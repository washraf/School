using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils.Domain.Entity;

namespace School.Management.Domain.Entities
{
    public class Course:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public Course()
        {
            Students = new HashSet<Student>();
            Instructors = new HashSet<Instructor>();

        }
    }
}