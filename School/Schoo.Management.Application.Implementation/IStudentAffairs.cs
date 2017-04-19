using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoo.Management.Domain.Entities;

namespace Schoo.Management.Application.Implementation
{
    public interface IStudentAffairs
    {
        void CreateStudent(Student student);
        void UpdateStudent(Student student);

        void RemoveStudent(Student student);
        List<Student> GetStudentsByName(string name);
        Student GetStudentById(int id);

    }
}
