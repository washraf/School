using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using log4net;
using log4net.Core;
using System.Reflection;
using System.Collections;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using Infrastructure.Utils.Domain.Core;
using Infrastructure.Utils.Domain.Core.Specification;
using Infrastructure.Utils.Trace;

namespace Infrastructure.Utils.Data.Core
{
    public abstract class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {

        #region --Private Memebrs
        private IQueryableUnitOfWork _unitOfWork;
        protected ITracer _tracer;
        #endregion

        #region --Constructor--
        public Repository(IQueryableUnitOfWork unitOfWork,ITracer tracer)
        {
            //check preconditions
            if (unitOfWork == (IQueryableUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork", "Unit of Work Cannot Be Null");
            if (tracer == (ITracer)null)
                throw new ArgumentNullException("tracer", "Tracer Cannot Be Null");
            //set internal values
            _unitOfWork = unitOfWork;
            _tracer = tracer;
            tracer.ConfigureTracer(this.GetType());
        }
        #endregion

        #region -- IRepository<TEntity> Implementation--
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork as IUnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {
            _tracer.LogInfo("Add called");

            //check item
            if (item == (TEntity)null)
                throw new ArgumentNullException("item", "Argument is null");
            IDbSet<TEntity> objectSet = CreateSet();
            objectSet.Add(item);
            _unitOfWork.Commit();
        }



        public virtual void Remove(TEntity item)
        {
            _tracer.LogInfo("Remove called");

            if (item == (TEntity) null)
            {
                var err= new ArgumentNullException("item", "Argument is null");
                _tracer.LogError(err.GetType().ToString(), err);

            }

            IDbSet<TEntity> objectSet = CreateSet();
            objectSet.Attach(item);
            objectSet.Remove(item);
            UnitOfWork.Commit();
        }

        public virtual void AttachItem(TEntity item)
        {
            if (item == (TEntity) null)
            {
                var err = new ArgumentNullException("item", "Argument is null");

                _tracer.LogError(err.GetType().ToString(), err);
            }

            (CreateSet()).Attach(item);
            
        }

        public virtual void Modify(TEntity item)
        {
            _tracer.LogInfo("Modify called");

            Type type = item.GetType();
            PropertyInfo prop = type.GetProperty("Id");
            object id = prop.GetValue(item);
             var old= CreateSet().Find(id);
            UnitOfWork.Entry(old).CurrentValues.SetValues(item);
            UnitOfWork.Commit();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            _tracer.LogInfo("Get All called");

            return(CreateSet()).AsEnumerable<TEntity>();
        }

       


        public virtual IEnumerable<TEntity> GetFilteredElements(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            _tracer.LogInfo("Get Filtered Elements called");

            //checking query arguments
            if (filter == (Expression<Func<TEntity, bool>>) null)
            {
                var err = new ArgumentNullException("filter", "Filter Cannot Be null");

                _tracer.LogError(err.GetType().ToString(), err);

                throw err;
            }

            //Create IDbSet and perform query
            return CreateSet().Where(filter).ToList();
        }
        public virtual IEnumerable<TEntity> GetFilteredElements(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter,
            params string[] includes)
        {
            _tracer.LogInfo("Get Filtered Elements called");

            //checking query arguments
            if (filter == (Expression<Func<TEntity, bool>>)null)
            {
                var err = new ArgumentNullException("filter", "Filter Cannot Be null");

                _tracer.LogError(err.GetType().ToString(), err);

                throw err;
            }

            //Create IDbSet and perform query
            var set =  CreateSet().AsQueryable();
            foreach (var inc in includes)
            {
                set = set.Include(inc);
            }
            return set.Where(filter).ToList();
        }

        public virtual IEnumerable<TEntity> GetAllElementsInclude(params string[] includes)
        {
            _tracer.LogInfo("Get Filtered Elements called");

            ////checking query arguments
            //if (filter == (Expression<Func<TEntity, bool>>)null)
            //{
            //    var err = new ArgumentNullException("filter", "Filter Cannot Be null");

            //    _tracer.LogError(err.GetType().ToString(), err);

            //    throw err;
            //}

            //Create IDbSet and perform query
            var set = CreateSet().AsQueryable();
            foreach (var inc in includes)
            {
                set = set.Include(inc);
            }
            return set.ToList();
        }


        public virtual IEnumerable<TEntity> GetFilteredElements<S>(
            System.Linq.Expressions.Expression<Func<TEntity, bool>> filter,
            int pageIndex, int pageCount,
            System.Linq.Expressions.Expression<Func<TEntity, S>> orderByExpression,
            bool ascending)
        {
            _tracer.LogInfo("Get Filtered Elements and Sort called");

            if (filter == (Expression<Func<TEntity, bool>>) null)
            {
                var err = new ArgumentNullException("filter", "Filter Cannot Be null");

                _tracer.LogError(err.GetType().ToString(), err);

                throw err;
            }
            if (orderByExpression == (Expression<Func<TEntity, S>>) null)
            {
                var err= new ArgumentNullException("orderByExpression", "");
                _tracer.LogError(err.GetType().ToString(), err);

                throw err;
            }


            //Create IObjectSet for this type and perform query
            IDbSet<TEntity> objectSet = CreateSet();

            return (ascending)
                ? objectSet
                    .Where(filter)
                    .OrderBy(orderByExpression)
                    .Skip(pageIndex * pageCount).Take(pageCount)
                    .ToList()
                : objectSet
                    .Where(filter)
                    .OrderByDescending(orderByExpression)
                    .Skip(pageIndex * pageCount).Take(pageCount)
                    .ToList();
        }


        public virtual IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            _tracer.LogInfo("Get By Specification Called");

            if (specification == (ISpecification<TEntity>) null)
            {
                var err= new ArgumentNullException("specification");

                _tracer.LogError(err.GetType().ToString(), err);
                throw err;
            }


            return (CreateSet().Where(specification.SatisfiedBy())
                                     .AsEnumerable<TEntity>());
        }

        #endregion

        #region -Private Methods---
        private IDbSet<TEntity> CreateSet()
        {
            _tracer.LogInfo("CreateSet Called");

            if (_unitOfWork != (IUnitOfWork) null)
            {
                IDbSet<TEntity> objectSet = _unitOfWork.CreateSet<TEntity>();
                return objectSet;
            }
            else
            {
                var err= new InvalidOperationException("");
                _tracer.LogError(err.GetType().ToString(), err);
                throw err;

            }
        }
        #endregion


        public bool UniqueName(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            _tracer.LogInfo("Get Filtered Elements called");
            //Create IDbSet and perform query
            //checking query arguments
            if (filter == (Expression<Func<TEntity, bool>>)null)
            {
                var err = new ArgumentNullException("filter", "Filter Cannot Be null");

                _tracer.LogError(err.GetType().ToString(), err);

                throw err;
            }
            var set = CreateSet().AsQueryable();
            if (set.Where(filter).SingleOrDefault() == null)
            return true; 
        else
	 return false;
        }

    }
}
