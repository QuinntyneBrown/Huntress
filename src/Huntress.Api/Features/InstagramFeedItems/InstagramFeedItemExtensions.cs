using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class InstagramFeedItemExtensions
    {
        public static InstagramFeedItemDto ToDto(this InstagramFeedItem instagramFeedItem)
        {
            return new()
            {
                InstagramFeedItemId = instagramFeedItem.InstagramFeedItemId,
                HtmlBody = instagramFeedItem.HtmlBody,
                ImageUrl = instagramFeedItem.ImageUrl
            };
        }
    }
}
