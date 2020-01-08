using System;

namespace RSSBackgroundWorkerBusiness.Repository
{
    public class RepositoryActionResult<T> where T : class
    {
        public T Entity { get; set; }

        public RepositoryActionStatus Status { get; set; }

        public Exception Exception { get; set; }

        public RepositoryActionResult(T entity, RepositoryActionStatus status)
        {
            Entity = entity;
            Status = status;
        }

        public RepositoryActionResult(T entity, RepositoryActionStatus status, Exception exception)
        {
            Entity = entity;
            Status = status;
            Exception = exception;
        }
    }
}
