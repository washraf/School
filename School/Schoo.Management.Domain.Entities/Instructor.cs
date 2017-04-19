using System.Collections.Generic;
using Infrastructure.Utils.Domain.Entity;

namespace School.Management.Domain.Entities
{
    public class Instructor : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Instructor()
        {
            Courses = new HashSet<Course>();
        }
    }
}