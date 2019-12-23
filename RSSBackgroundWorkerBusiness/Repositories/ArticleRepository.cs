using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class ArticleRepository : GenericRepository<Article>
    {
        public ArticleRepository(RSSContext context) : base(context)
        {
        }
    }
}
