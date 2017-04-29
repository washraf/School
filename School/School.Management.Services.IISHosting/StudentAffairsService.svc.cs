using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Infrastructure.Utils.Trace;
using Infrastructure.Utils.WCF;
using Infrastructure.Utils.WCF.MEF;
using School.Management.Application.Contracts;
using School.Management.Services.Contracts;

namespace School.Management.Services.IISHosting
{
    [Export(typeof(IStudentAffairsService))]
    [MefBehavior]
    public class StudentAffairsService : Implementation.StudentAffairsService
    {
        [ImportingConstructor]
        public StudentAffairsService(IStudentAffairs studentAffairs,
            ITracer tracer) : base(studentAffairs, tracer)
        {
        }
    }
}
