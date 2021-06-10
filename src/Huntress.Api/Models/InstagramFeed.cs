using System;
using System.Collections.Generic;

namespace Huntress.Api.Models
{
    public class InstagramFeed
    {
        public Guid InstagramFeedId { get; private set; }
        public List<InstagramFeedItem> InstagramFeedItems { get; private set; } = new();
        public string AccountName { get; private set; }
        public string AccountHandle { get; private set; }

        public InstagramFeed(string accountName, string accountHandle)
        {
            AccountName = accountName;
            AccountHandle = accountHandle;
        }

        private InstagramFeed()
        {

        }
    }
}
