using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IChannelRepository
        : IGenericRepository<Channel>
    {
        Channel GetChannelByURL(string url);
    }
}
