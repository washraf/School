using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.WCF;
using School.Management.Domain.Entities;

namespace School.Management.Services.Contracts
{
    [ServiceContract]
    public interface IStudentAffairsService:IServiceBase
    {
        [OperationContract]
        bool CreateStudent(Student student);
        [OperationContract]
        bool UpdateStudent(Student student);
        [OperationContract]
        bool RemoveStudent(Student student);
        [OperationContract]
        List<Student> GetStudentsByName(string name);
        [OperationContract]
        [FaultContract(typeof(Exception))]
        Student GetStudentById(int id);
        [OperationContract]
        bool RegisterToCourse(int studentId, int courseId);
    }
}
