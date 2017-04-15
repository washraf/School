using System.Collections.Generic;

namespace Schoo.Management.Domain.Entities
{
    public class Instructor
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