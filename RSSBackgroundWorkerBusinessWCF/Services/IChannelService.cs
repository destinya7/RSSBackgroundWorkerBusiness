using RSSBackgroundWorkerBusinessWCF.Messages;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RSSBackgroundWorkerBusinessWCF.Services
{
    [ServiceContract]
    public interface IChannelService
    {
        [OperationContract]
        IEnumerable<Channel> GetChannels();

        [OperationContract]
        Channel GetChannel(string url);

        [OperationContract]
        Task<ChannelMessage> AddChannel(Channel channel);

        [OperationContract]
        Task<ChannelMessage> UpdateChannel(Channel channel);

        [OperationContract]
        Task<ChannelMessage> DeleteChannel(string url);
    }
}
