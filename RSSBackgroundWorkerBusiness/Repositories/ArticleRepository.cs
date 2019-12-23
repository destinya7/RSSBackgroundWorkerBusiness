using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(RSSContext context) : base(context)
        {
        }
    }
}
