using System.Collections.Generic;
using System.Threading.Tasks;
using RSSBackgroundWorkerBusiness.Models;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IChannelRepository
        : IGenericRepository<Channel>
    {
        Task<Channel> GetChannelByURL(string url);

        Task<List<Channel>> GetChannelsLastUpdatedWithin(double minutes);
    }
}
