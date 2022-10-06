using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class InstagramFeedExtensions
    {
        public static InstagramFeedDto ToDto(this InstagramFeed instagramFeed)
        {
            return new()
            {
                InstagramFeedId = instagramFeed.InstagramFeedId,
                AccountHandle = instagramFeed.AccountHandle,
                AccountName = instagramFeed.AccountName
            };
        }
    }
}
