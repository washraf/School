using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils.Domain.Entity;

namespace School.Management.Domain.Entities
{
    public class ClassRoom:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public ClassRoom()
        {
            Courses = new HashSet<Course>();
        }
    }
}