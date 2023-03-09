// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate;

public static class JsonPropertyModelExtensions
{
    public static JsonPropertyModelDto ToDto(this JsonPropertyModel jsonPropertyModel)
    {
        return new JsonPropertyModelDto
        {
            Name = jsonPropertyModel.Name,
            JsonPropertyModelId = jsonPropertyModel.JsonPropertyModelId,
        };

    }

    public static List<JsonPropertyModelDto> ToDtos(this List<JsonPropertyModel> jsonPropertyModels)
    {
        return jsonPropertyModels.Select(x => x.ToDto()).ToList();
    }

    public async static Task<List<JsonPropertyModelDto>> ToDtosAsync(this IQueryable<JsonPropertyModel> jsonPropertyModels,CancellationToken cancellationToken)
    {
        return await jsonPropertyModels.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


