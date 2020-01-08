using System;
using System.Runtime.Serialization;

namespace RSSBackgroundWorkerBusinessWCF.Messages
{
    [DataContract]
    public class ChannelMessage
    {
        [DataMember]
        public Channel Message { get; set; }

        [DataMember]
        public MessageStatus Status { get; set; }

        [DataMember]
        public Exception Exception { get; set; }

        public ChannelMessage() { }

        public ChannelMessage(Channel message, MessageStatus status, Exception exception)
        {
            Message = message;
            Status = status;
            Exception = exception;
        }
    }
}