using RSSBackgroundWorkerBusiness.Models;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IChannelRepository
        : IGenericRepository<Channel>
    {
        Task<Channel> GetChannelByURL(string url);
    }
}
