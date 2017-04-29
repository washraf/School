using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Infrastructure.Utils.Trace;
using Infrastructure.Utils.WCF.MEF;
using School.Management.Application.Contracts;
using School.Management.Services.Contracts;
using School.Management.Services.Implementation;

namespace School.Management.Services.IISHTTPS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    [Export(typeof(IStudentAffairsService))]
    [MefBehavior]
    public class StudentService : StudentAffairsService
    {
        [ImportingConstructor]
        public StudentService(IStudentAffairs studentAffairs,
            ITracer tracer) : base(studentAffairs, tracer)
        {
        }
    }
}
