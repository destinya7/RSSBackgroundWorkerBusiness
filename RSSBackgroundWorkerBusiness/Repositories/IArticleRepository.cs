using RSSBackgroundWorkerBusiness.Models;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Task<Article> GetArticleByURL(string url);
    }
}
