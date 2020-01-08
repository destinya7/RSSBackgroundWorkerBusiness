using RSSBackgroundWorkerBusiness.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repository
{
    public interface IArticleRepository
    {
        IQueryable<Article> GetAll();

        Article Get(int id);

        Article GetByUrl(string url);

        Task<RepositoryActionResult<Article>> Add(Article article);

        Task<RepositoryActionResult<Article>> Update(Article article);

        Task<RepositoryActionResult<Article>> Delete(int id);
    }
}