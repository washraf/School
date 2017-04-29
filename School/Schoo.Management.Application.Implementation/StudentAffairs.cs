using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Management.Application.Contracts;
using School.Management.Domain.Contracts;
using School.Management.Domain.Entities;

namespace School.Management.Application.Implementation
{
    [Export(typeof(IStudentAffairs))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StudentAffairs: IStudentAffairs
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        [ImportingConstructor]
        public StudentAffairs(IStudentRepository studentRepository,ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public bool CreateStudent(Student student)
        {
            if (student.IsValid)
                _studentRepository.Add(student);
            return true;

        }

        public bool UpdateStudent(Student student)
        {
            if (student.IsValid)
                _studentRepository.Modify(student);
            return true;

        }

        public bool RemoveStudent(Student student)
        {
            if (student.IsValid)
                _studentRepository.Remove(student);
            return true;

        }

        public List<Student> GetStudentsByName(string name)
        {
            return _studentRepository.GetFilteredElements(x => x.Name.Contains(name)).ToList();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetFilteredElements(x => x.Id == id).SingleOrDefault();

        }

        public bool RegisterToCourse(int studentId, int courseId)
        {
           var course =  _courseRepository.GetFilteredElements(x => x.Id == courseId).SingleOrDefault();
            var student = _studentRepository.GetFilteredElements(x => x.Id == studentId).SingleOrDefault();
            if (student != null && course != null)
            {
                student.Register(course);   
            }
            _studentRepository.Modify(student);

            return true;
        }
    }
}
