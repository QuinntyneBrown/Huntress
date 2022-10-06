namespace Huntress.Domain.Entities;

public class InstagramFeedItem
{
    public Guid InstagramFeedItemId { get; private set; }
    public string ImageUrl { get; private set; } = "";
    public string HtmlBody { get; private set; } = "";
    public InstagramFeedItem(string imageUrl, string htmlBody)
    {
        ImageUrl = imageUrl;
        HtmlBody = htmlBody;
    }

    private InstagramFeedItem()
    {

    }
}
