using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class HtmlContentExtensions
    {
        public static HtmlContentDto ToDto(this HtmlContent htmlContent)
        {
            return new ()
            {
                HtmlContentId = htmlContent.HtmlContentId,
                HtmlContentType = htmlContent.HtmlContentType,
                Name = htmlContent.Name,
                Body = htmlContent.Body
            };
        }
        
    }
}
