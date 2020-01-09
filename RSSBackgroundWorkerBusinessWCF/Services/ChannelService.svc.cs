using RSSBackgroundWorkerBusiness.Repositories;
using RSSBackgroundWorkerBusinessWCF.Factories;
using RSSBackgroundWorkerBusinessWCF.Messages;
using RSSBackgroundWorkerBusinessWCF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusinessWCF.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _repo;
        private readonly IChannelFactory _channelFactory;

        public ChannelService(
            IChannelRepository repo,
            IChannelFactory factory
        )
        {
            this._repo = repo;
            this._channelFactory = factory;
        }

        public IEnumerable<Channel> GetChannels()
        {
            try
            {
                var channels = _repo.GetAll();
                return channels.ToList().Select(c => _channelFactory.CreateChannel(c));
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to process the request");
            }
        }

        public async Task<Channel> GetChannel(string url)
        {
            try
            {
                var channel = await _repo.GetByUrl(url);

                if (channel != null)
                {
                    return _channelFactory.CreateChannel(channel);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ChannelMessage> AddChannel(Channel channel)
        {
            try
            {
                var channelEntity = _channelFactory.CreateChannel(channel);
                var result = await _repo.Add(channelEntity);

                return new ChannelMessage(
                    _channelFactory.CreateChannel(result.Entity),
                    StatusConverter.ConvertToMessageStatus(result.Status),
                    result.Exception);
            }
            catch (Exception ex)
            {
                return new ChannelMessage(
                    channel, MessageStatus.Error, ex);
            }
        }

        public async Task<ChannelMessage> UpdateChannel(Channel channel)
        {
            try
            {
                var channelEntity = _channelFactory.CreateChannel(channel);
                var result = await _repo.Update(channelEntity);
                var message = result.Entity != null
                    ? _channelFactory.CreateChannel(result.Entity)
                    : null;

                return new ChannelMessage(
                    message,
                    StatusConverter.ConvertToMessageStatus(result.Status),
                    result.Exception);
            }
            catch (Exception ex)
            {
                return new ChannelMessage(
                    channel, MessageStatus.Error, ex);
            }
        }

        public async Task<ChannelMessage> DeleteChannel(string url)
        {
            try
            {
                var result = await _repo.Delete(url);
                var message = result.Entity != null
                    ? _channelFactory.CreateChannel(result.Entity)
                    : null;

                return new ChannelMessage(
                    message,
                    StatusConverter.ConvertToMessageStatus(result.Status),
                    result.Exception);
            }
            catch (Exception ex)
            {
                return new ChannelMessage(
                    null, MessageStatus.Error, ex);
            }
        }
    }
}
