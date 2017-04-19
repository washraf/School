using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Utils.Domain.Core
{
    /// <summary>
    /// Allow Query Features
    /// </summary>
    public interface ISql
    {
        /// <summary>
        /// Execute a SQL Query and Return the result Collection
        /// </summary>
        /// <typeparam name="TEntity">The result type</typeparam>
        /// <param name="sqlQuery">Sql Query String</param>
        /// <param name="parameters">Set of Paramets to be included in the Query</param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand">Sql Command String</param>
        /// <param name="parameters">Set of Paramets to be included in the command</param>
        /// <returns></returns>
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
