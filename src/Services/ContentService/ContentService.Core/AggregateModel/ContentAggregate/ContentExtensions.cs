// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.ContentAggregate;

public static class ContentExtensions
{
    public static ContentDto ToDto(this Content content)
    {
        return new ContentDto
        {

        };
    }

    public static async Task<List<ContentDto>> ToDtosAsync(this IQueryable<Content> content, CancellationToken cancellationToken)
    {
        return await content.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

    public static List<ContentDto> ToDtos(this IEnumerable<Content> content)
    {
        return content.Select(x => x.ToDto()).ToList();
    }
}



