using RSSBackgroundWorkerBusiness.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IArticleRepository
    {
        IQueryable<Article> GetAll();

        Article Get(int id);

        Task<Article> GetByUrl(string url);

        Task<RepositoryActionResult<Article>> Add(Article article);

        Task<RepositoryActionResult<Article>> Update(Article article);

        Task<RepositoryActionResult<Article>> Delete(int id);
    }
}