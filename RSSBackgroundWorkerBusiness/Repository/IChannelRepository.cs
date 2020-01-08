using RSSBackgroundWorkerBusiness.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repository
{
    public interface IChannelRepository
    {
        IQueryable<Channel> GetAll();

        Channel GetByUrl(string url);

        Task<RepositoryActionResult<Channel>> Add(Channel channel);

        Task<RepositoryActionResult<Channel>> Update(Channel channel);

        Task<RepositoryActionResult<Channel>> Delete(Channel channel);

        Task<RepositoryActionResult<Channel>> Delete(string url);
    }
}