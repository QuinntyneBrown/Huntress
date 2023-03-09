// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonSchemaModelAggregate;

public class JsonSchemaModel
{
    public JsonSchemaModel(string name)
    {
        Name = name;
        Properties = new List<JsonPropertyModel>();        
    }
    public Guid JsonSchemaModelId { get; set; }
    public Guid? UserId { get; set; }
    public string Name { get; set; }
    public List<JsonPropertyModel> Properties { get; set; }
}