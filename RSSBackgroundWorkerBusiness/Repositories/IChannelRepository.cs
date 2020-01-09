using RSSBackgroundWorkerBusiness.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repositories
{
    public interface IChannelRepository
    {
        IQueryable<Channel> GetAll();

        Task<Channel> GetByUrl(string url);

        Task<Channel> Get(object id);

        IQueryable<Channel> GetChannelsLastUpdatedWithin(double minutes);

        Task<RepositoryActionResult<Channel>> Add(Channel channel);

        Task<RepositoryActionResult<Channel>> Update(Channel channel);

        Task<RepositoryActionResult<Channel>> Delete(Channel channel);

        Task<RepositoryActionResult<Channel>> Delete(string url);
    }
}