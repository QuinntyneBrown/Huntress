// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate;

public static class JsonSchemaModelExtensions
{
    public static JsonSchemaModelDto ToDto(this JsonSchemaModel jsonSchemaModel)
    {
        return new JsonSchemaModelDto
        {
            JsonSchemaModelId = jsonSchemaModel.JsonSchemaModelId,
            Name = jsonSchemaModel.Name,
            Properties = jsonSchemaModel.Properties.ToDtos()
        };
    }

    public async static Task<List<JsonSchemaModelDto>> ToDtosAsync(this IQueryable<JsonSchemaModel> jsonSchemaModels,CancellationToken cancellationToken)
    {
        return await jsonSchemaModels.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


