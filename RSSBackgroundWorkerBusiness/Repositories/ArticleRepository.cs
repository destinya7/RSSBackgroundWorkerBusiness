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
    }
}
