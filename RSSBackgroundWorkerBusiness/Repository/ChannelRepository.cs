using RSSBackgroundWorkerBusiness.DAL;
using RSSBackgroundWorkerBusiness.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusiness.Repository
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly RSSContext _context;

        public ChannelRepository(RSSContext context)
        {
            this._context = context;
        }

        public IQueryable<Channel> GetAll()
        {
            return _context.Channels;
        }

        public Channel GetByUrl(string url)
        {
            return _context.Channels.FirstOrDefault(c => c.RSS_URL == url);
        }

        public async Task<RepositoryActionResult<Channel>> Add(Channel channel)
        {
            try
            {
                channel.DateCreated = DateTime.UtcNow;
                channel.DateModified = DateTime.UtcNow;

                _context.Channels.Add(channel);

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Created);
                }

                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.NothingModified);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Error, ex);
            }
        }

        public async Task<RepositoryActionResult<Channel>> Update(Channel channel)
        {
            try
            {
                var existingChannel = await _context.Channels.FirstOrDefaultAsync(
                    c => c.RSS_URL == channel.RSS_URL);

                if (existingChannel != null)
                {
                    existingChannel.DateModified = DateTime.Now;
                    existingChannel.Title = channel.Title;
                    existingChannel.Description = channel.Description;
                    existingChannel.Link = channel.Link;
                    existingChannel.ChannelImage = channel.ChannelImage;

                    _context.Entry(existingChannel).State = EntityState.Modified;

                    var result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Updated);
                    }

                    return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.NothingModified);
                }

                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Error, ex);
            }
        }

        public async Task<RepositoryActionResult<Channel>> Delete(Channel channel)
        {
            try
            {
                var existingChannel = await _context.Channels.FirstOrDefaultAsync(
                    c => c.RSS_URL == channel.RSS_URL);

                if (existingChannel != null)
                {
                    _context.Channels.Remove(existingChannel);

                    var result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Deleted);
                    }

                    return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.NothingModified);
                }

                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(channel, RepositoryActionStatus.Error, ex);
            }
        }

        public async Task<RepositoryActionResult<Channel>> Delete(string url)
        {
            try
            {
                var existingChannel = await _context.Channels.FirstOrDefaultAsync(
                    c => c.RSS_URL == url);

                if (existingChannel != null)
                {
                    _context.Channels.Remove(existingChannel);

                    var result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        return new RepositoryActionResult<Channel>(existingChannel, RepositoryActionStatus.Deleted);
                    }

                    return new RepositoryActionResult<Channel>(existingChannel, RepositoryActionStatus.NothingModified);
                }

                return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Channel>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
