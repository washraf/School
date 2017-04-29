using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Utils.Trace;
using Infrastructure.Utils.WCF;
using Infrastructure.Utils.WCF.MEF;
using School.Management.Application.Contracts;
using School.Management.Domain.Entities;
using School.Management.Services.Contracts;

namespace School.Management.Services.Implementation
{
    //[Export(typeof(IStudentAffairsService))]
    //[MefBehavior]
    public class StudentAffairsService: ServiceBase,IStudentAffairsService
    {
        private readonly IStudentAffairs _studentAffairs;

        //[ImportingConstructor]
        public StudentAffairsService(IStudentAffairs studentAffairs, ITracer tracer) : 
            base(tracer)
        {
            _studentAffairs = studentAffairs;

            if (studentAffairs == (IStudentAffairs)null)
                throw new ArgumentNullException("studentAffairs", "Student Affairs Should Not Be Null");
            this._studentAffairs = studentAffairs;
            tracer.ConfigureTracer(this.GetType());
            tracer.LogInfo("StudentManagementService Called");
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        public bool CreateStudent(Student student)
        {
            #region --Show Different Identities--
                //Host Identity
            var host = WindowsIdentity.GetCurrent().Name;
            var windowsName = ServiceSecurityContext.Current.WindowsIdentity.Name;
            var primaryIdentityName = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            var threadName = Thread.CurrentPrincipal.Identity.Name;
            #endregion
            return ExecuteTransactional(
                () =>
                {
                    return _studentAffairs.CreateStudent(student);
                }
               );
        }

        public bool UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RegisterToCourse(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        
    }
}
