using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoo.Management.Application.Implementation;
using Schoo.Management.Domain.Contracts;
using Schoo.Management.Domain.Entities;

namespace Schoo.Management.Application.Contracts
{
    public class StudentAffairs: IStudentAffairs
    {
        private readonly IStudentRepository _studentRepository;

        public StudentAffairs(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            if(student.IsValid)
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
            return _studentRepository.GetFilteredElements(x => x.Id==id).SingleOrDefault();

        }
    }
}
