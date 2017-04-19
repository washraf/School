using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Trace;
using School.Management.Application.Contracts;
using School.Management.Application.Implementation;
using School.Management.Domain.Contracts;
using School.Management.Infrastructure.DataAccess.Context;
using School.Management.Infrastructure.DataAccess.Repositories;

namespace School.Management.Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ManagementContext();
            IStudentRepository studentRepository = new StudentRepository(context, new Log4NetTracer());
            ICourseRepository courseRepository = new CourseRepository(context, new Log4NetTracer());

            IStudentAffairs affairs = new StudentAffairs(studentRepository,courseRepository);
            affairs.RegisterToCourse(1,1);
        }
    }
}
