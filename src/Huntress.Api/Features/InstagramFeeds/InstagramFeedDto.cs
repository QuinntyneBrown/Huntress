using System;
using System.Collections.Generic;

namespace Huntress.Api.Features
{
    public class InstagramFeedDto
    {
        public Guid? InstagramFeedId { get; set; }
        public List<InstagramFeedItemDto> InstagramFeedItems { get; set; } = new();
        public string AccountName { get; set; }
        public string AccountHandle { get; set; }
    }
}
