using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Management.Application.Contracts;
using School.Management.Domain.Contracts;
using School.Management.Domain.Entities;

namespace School.Management.Application.Implementation
{
    public class StudentAffairs: IStudentAffairs
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentAffairs(IStudentRepository studentRepository,ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public void CreateStudent(Student student)
        {
            if (student.IsValid)
                _studentRepository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            if (student.IsValid)
                _studentRepository.Modify(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student.IsValid)
                _studentRepository.Remove(student);
        }

        public List<Student> GetStudentsByName(string name)
        {
            return _studentRepository.GetFilteredElements(x => x.Name.Contains(name)).ToList();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetFilteredElements(x => x.Id == id).SingleOrDefault();

        }

        public void RegisterToCourse(int studentId, int courseId)
        {
           var course =  _courseRepository.GetFilteredElements(x => x.Id == courseId).SingleOrDefault();
            var student = _studentRepository.GetFilteredElements(x => x.Id == studentId).SingleOrDefault();
            if (student != null && course != null)
            {
                student.Register(course);   
            }
            _studentRepository.Modify(student);


        }
    }
}
