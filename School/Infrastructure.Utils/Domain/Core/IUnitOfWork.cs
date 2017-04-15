using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Infrastructure.CrossCutting.Utils.Domain.Core
{
    /// <summary>
    /// Unit of Work Implementation
    /// Implements ISql<see cref="ISql"/> and IDisposable<see cref="IDisposable"/>
    /// </summary>
    public interface IUnitOfWork:ISql,IDisposable
    {
        /// <summary>
        /// Save Changes
        /// </summary>
        void Commit();
        DbEntityEntry Entry(object TEntity);
    }
}
