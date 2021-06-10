using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class ImageContentExtensions
    {
        public static ImageContentDto ToDto(this ImageContent imageContent)
        {
            return new ()
            {
                ImageContentId = imageContent.ImageContentId,
                ImageContentType = imageContent.ImageContentType,
                Url = imageContent.Url
            };
        }        
    }
}
