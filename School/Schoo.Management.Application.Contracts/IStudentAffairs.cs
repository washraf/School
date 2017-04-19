using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Management.Domain.Contracts;
using School.Management.Domain.Entities;

namespace School.Management.Application.Contracts
{
    public interface IStudentAffairs
    {
        void CreateStudent(Student student);
        void UpdateStudent(Student student);

        void RemoveStudent(Student student);
        List<Student> GetStudentsByName(string name);
        Student GetStudentById(int id);
        void RegisterToCourse(int studentId, int courseId);
        
    }
}
