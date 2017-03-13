using sRecipe.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.ActionResults
{
    /// <summary>
    /// Insert, Update, Delete result object
    /// include actionresult code
    /// and the object of operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryActionResult<T> 
                where T : class
    {
        
        public T Entity { get; private set; }
        public RepositoryActionStatus Status { get; private set; }

        public Exception Exception { get; private set; }


        public RepositoryActionResult(T entity, RepositoryActionStatus status)
        {
            Entity = entity;
            Status = status;
        }

        public RepositoryActionResult(T entity, RepositoryActionStatus status, Exception exception) : this(entity, status)
        {
            Exception = exception;
        }

    }
}
