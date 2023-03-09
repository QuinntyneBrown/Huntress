// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContentService.Core.AggregateModel.JsonPropertyModelAggregate;

public class JsonPropertyModel
{
    public JsonPropertyModel(string name, string type)
    {
        Name = name;
        Type = type;

    }
    public Guid JsonPropertyModelId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}


