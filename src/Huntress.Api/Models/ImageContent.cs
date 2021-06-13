using System;

namespace Huntress.Api.Models
{
    public class ImageContent
    {
        public Guid ImageContentId { get; private set; }
        public ImageContentType ImageContentType { get; private set; }
        public string Url { get; private set; }

        public ImageContent(ImageContentType imageContentType, string url)
        {
            ImageContentType = imageContentType;
            Url = url;
        }

        private ImageContent()
        {

        }
    }
}
