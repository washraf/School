using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Domain.Core;
using Schoo.Management.Domain.Entities;

namespace Schoo.Management.Domain.Contracts
{
    public interface IStudentRepository:IRepository<Student>
    {
    }
}
