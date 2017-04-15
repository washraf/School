using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race.Infrastructure.CrossCutting.Utils.Data.Core;
using Race.Infrastructure.CrossCutting.Utils.Domain.Core;

namespace Schoo.Management.Infrastructure.DataAccess.UnitOfWork
{
    public interface IManagementUnitOfWork: IQueryableUnitOfWork
    {
    }
}
