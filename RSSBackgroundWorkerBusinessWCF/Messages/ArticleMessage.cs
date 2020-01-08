using System;
using System.Runtime.Serialization;

namespace RSSBackgroundWorkerBusinessWCF.Messages
{
    public class ArticleMessage
    {
        [DataMember]
        public Article Message { get; set; }

        [DataMember]
        public MessageStatus Status { get; set; }

        [DataMember]
        public Exception Exception { get; set; }

        public ArticleMessage() { }

        public ArticleMessage(Article message, MessageStatus status, Exception exception)
        {
            Message = message;
            Status = status;
            Exception = exception;
        }
    }
}