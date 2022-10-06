using Huntress.Domain.Enums;

namespace Huntress.Domain.Entities;

public class SocialShare
{
    public Guid SocialShareId { get; private set; }
    public SocialShareType ShareType { get; private set; } = SocialShareType.Facebook;
    public string Url { get; private set; } = "";

    public SocialShare(SocialShareType shareType, string url)
    {
        ShareType = shareType;
        Url = url;
    }

    private SocialShare()
    {

    }
}
