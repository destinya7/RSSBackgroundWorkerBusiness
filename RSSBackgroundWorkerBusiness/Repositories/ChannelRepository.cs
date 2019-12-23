using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public class ChannelRepository : GenericRepository<RSSContext, Channel>,
                                     IChannelRepository
    {
        public ChannelRepository(RSSContext context) : base(context)
        {
        }

        public Channel GetChannelByURL(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}
