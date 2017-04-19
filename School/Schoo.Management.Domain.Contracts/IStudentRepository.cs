using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Domain.Core;
using School.Management.Domain.Entities;

namespace School.Management.Domain.Contracts
{
    public interface IStudentRepository:IRepository<Student>
    {
    }
}
