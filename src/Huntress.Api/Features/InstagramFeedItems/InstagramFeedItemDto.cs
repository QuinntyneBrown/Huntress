using System;

namespace Huntress.Api.Features
{
    public class InstagramFeedItemDto
    {
        public Guid? InstagramFeedItemId { get; set; }
        public string ImageUrl { get; set; }
        public string HtmlBody { get; set; }
    }
}
