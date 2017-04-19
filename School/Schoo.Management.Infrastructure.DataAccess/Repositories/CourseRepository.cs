using Infrastructure.Utils.Data.Core;
using Infrastructure.Utils.Trace;
using School.Management.Domain.Contracts;
using School.Management.Domain.Entities;
using School.Management.Infrastructure.DataAccess.UnitOfWork;

namespace School.Management.Infrastructure.DataAccess.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(IManagementUnitOfWork unitOfWork, ITracer tracer)
            : base(unitOfWork, tracer)
        {
        }
    }
}