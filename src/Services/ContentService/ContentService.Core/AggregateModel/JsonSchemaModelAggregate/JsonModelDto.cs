// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate;

public class JsonSchemaModelDto
{
    public Guid? JsonSchemaModelId { get; set; }
    public string Name { get; set; }
    public List<JsonPropertyModelDto>? Properties { get; set; }
}


