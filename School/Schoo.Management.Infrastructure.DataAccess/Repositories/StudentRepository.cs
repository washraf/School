using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Data.Core;
using Infrastructure.Utils.Trace;
using School.Management.Domain.Contracts;
using School.Management.Domain.Entities;
using School.Management.Infrastructure.DataAccess.UnitOfWork;

namespace School.Management.Infrastructure.DataAccess.Repositories
{
    [Export(typeof(IStudentRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StudentRepository:Repository<Student>,
        IStudentRepository
    {
        [ImportingConstructor]
        public StudentRepository(IManagementUnitOfWork unitOfWork, ITracer tracer) 
            : base(unitOfWork, tracer)
        {
        }
    }
}
