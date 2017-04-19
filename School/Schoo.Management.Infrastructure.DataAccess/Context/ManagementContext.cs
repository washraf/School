using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoo.Management.Domain.Entities;
using Schoo.Management.Infrastructure.DataAccess.UnitOfWork;

namespace Schoo.Management.Infrastructure.DataAccess.Context
{
    public class ManagementContext:DbContext,IManagementUnitOfWork
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }

        #region--Code To Implement the IUnitOfWorkInterface--

        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>() as IDbSet<TEntity>;
        }

        public void Commit()
        {
            //Default option is DetectChangesBeforeSave
            base.SaveChanges();
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
        #endregion
    }
}


