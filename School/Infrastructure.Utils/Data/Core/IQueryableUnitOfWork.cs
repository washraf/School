using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race.Infrastructure.CrossCutting.Utils.Domain.Core;

namespace Race.Infrastructure.CrossCutting.Utils.Data.Core
{
    public interface IQueryableUnitOfWork:IUnitOfWork
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }
}
