using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class SocialShareExtensions
    {
        public static SocialShareDto ToDto(this SocialShare socialShare)
        {
            return new()
            {
                SocialShareId = socialShare.SocialShareId,
                ShareType = socialShare.ShareType,
                Url = socialShare.Url
            };
        }
    }
}
