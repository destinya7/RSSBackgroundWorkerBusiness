using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public override void Insert(Channel channel)
        {
            channel.DateCreated = DateTime.Now;
            channel.DateModified = DateTime.Now;
            channel.Articles.ForEach(a =>
            {
                a.DateCreated = DateTime.Now;
                a.DateModified = DateTime.Now;
            });
            Table.Add(channel);
        }

        public Task<Channel> GetChannelByURL(string url)
        {
            return Table.FirstOrDefaultAsync(t => t.Link == url);
        }
    }
}
