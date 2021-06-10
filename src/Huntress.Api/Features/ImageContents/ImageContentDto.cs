using Huntress.Api.Models;
using System;

namespace Huntress.Api.Features
{
    public class ImageContentDto
    {
        public Guid ImageContentId { get; set; }
        public ImageContentType ImageContentType { get; set; }
        public string Url { get; set; }
    }
}
