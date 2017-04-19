using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Domain.Entity;

namespace School.Management.Domain.Entities
{
  

public class Student : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "Name", ErrorMessageResourceType = typeof(Infrastructure.Utils.Domain.Resources.StudentValidationMessages))]
        // [RegularExpression("\\w\\d")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(5, 18)]
        public int Age { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public override bool IsValid
        {
            get { return base.IsValid && this.Name != "Hamada"; }
        }

        public void Register(Course course)
        {
            Courses.Add(course);
        }
    }
}
