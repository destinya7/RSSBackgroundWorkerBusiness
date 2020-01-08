using RSSBackgroundWorkerBusinessWCF.Messages;
using System.Collections.Generic;
using System.Linq;

namespace RSSBackgroundWorkerBusinessWCF.Factories
{
    public class ChannelFactory : IChannelFactory
    {
        private readonly IArticleFactory _articleFactory;

        public ChannelFactory(IArticleFactory articleFactory)
        {
            this._articleFactory = articleFactory;
        }

        public Channel CreateChannel(RSSBackgroundWorkerBusiness.Models.Channel channel)
        {
            return new Channel
            {
                Title = channel.Title,
                RSS_URL = channel.RSS_URL,
                Link = channel.Link,
                Description = channel.Description,
                ChannelImage = new Channel.Image
                {
                    URL = channel.ChannelImage?.URL,
                    Title = channel.ChannelImage?.Title
                }
            };
        }

        public RSSBackgroundWorkerBusiness.Models.Channel CreateChannel(
            Channel channel)
        {
            return new RSSBackgroundWorkerBusiness.Models.Channel
            {
                Title = channel.Title,
                RSS_URL = channel.RSS_URL,
                Link = channel.Link,
                Description = channel.Description,
                ChannelImage = new RSSBackgroundWorkerBusiness.Models.Channel.Image
                {
                    URL = channel.ChannelImage?.URL,
                    Title = channel.ChannelImage?.Title
                }
            };
        }
    }
}