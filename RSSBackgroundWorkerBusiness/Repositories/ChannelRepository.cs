using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class ChannelRepository : GenericRepository<Channel>
    {
        public ChannelRepository(RSSContext context) : base(context)
        {
        }
    }
}
