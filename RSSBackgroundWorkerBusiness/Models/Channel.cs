using System;
using System.Collections.Generic;

namespace RSSBackgroundWorkerBusiness.Models
{
    public class Channel : BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string RSS_URL { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public Image ChannelImage { get; set; }

        public virtual List<Article> Articles { get; set; }

        public class Image
        {
            public string URL { get; set; }

            public string Title { get; set; }
        }
    }
}
