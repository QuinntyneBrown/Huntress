using Huntress.Api.Extensions;
using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class ContentExtensions
    {
        public static ContentDto ToDto(this Content content)
        {
            return new()
            {
                ContentId = content.ContentId,
                Name = content.Name,
                Json = content.Json,
                Slug = content.Name.Slugify()
            };
        }
    }
}
