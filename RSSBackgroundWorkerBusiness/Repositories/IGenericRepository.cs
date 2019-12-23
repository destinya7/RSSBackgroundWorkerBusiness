using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        Task Save();
    }
}
