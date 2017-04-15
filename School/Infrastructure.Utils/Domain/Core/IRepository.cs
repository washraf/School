using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Race.Infrastructure.CrossCutting.Utils.Domain.Core.Specification;

namespace Race.Infrastructure.CrossCutting.Utils.Domain.Core
{
    /// <summary>
    /// This is the Basic Interface for all the Repositories that will exist in our solutoin
    /// </summary>
    /// <typeparam name="TEntity">Must be value type</typeparam>
    public interface IRepository<TEntity> where TEntity: class
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(TEntity item);
        void Remove(TEntity item);
        void AttachItem(TEntity item);
        void Modify(TEntity item);
        IEnumerable<TEntity> GetAll();
        
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetFilteredElements(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter,
            params string[] includes);
        IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageCount, Expression<Func<TEntity, S>> orderByExpression, bool ascending);
        IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification);
    }
}
