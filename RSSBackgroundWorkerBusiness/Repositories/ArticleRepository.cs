using System.Data.Entity;
using System.Threading.Tasks;
using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class ArticleRepository : GenericRepository<RSSContext, Article>,
                                     IArticleRepository
    {
        public ArticleRepository(RSSContext context) : base(context)
        {
        }

        public Task<Article> GetArticleByURL(string url)
        {
            return Table.FirstOrDefaultAsync(a => a.Link == url);
        }
    }
}
