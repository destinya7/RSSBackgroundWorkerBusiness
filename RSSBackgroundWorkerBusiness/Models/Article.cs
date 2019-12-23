using System;

namespace RSSBackgroundWorkerBusiness.Models
{
    public class Article : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime PubDate { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
