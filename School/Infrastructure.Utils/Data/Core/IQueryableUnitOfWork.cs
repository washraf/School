using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Domain.Core;

namespace Infrastructure.Utils.Data.Core
{
    public interface IQueryableUnitOfWork:IUnitOfWork
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }
}
