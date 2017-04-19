using System;
using System.Collections.Generic;
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
    public class StudentRepository:Repository<Student>,IStudentRepository
    {
        public StudentRepository(IManagementUnitOfWork unitOfWork, ITracer tracer) 
            : base(unitOfWork, tracer)
        {
        }
    }
}
