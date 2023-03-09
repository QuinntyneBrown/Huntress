// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;

namespace ContentService.Core.AggregateModel.ContentAggregate;

public class Content
{
    public Guid ContentId { get; set; }
    public Guid? UserId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public Guid JsonSchemaModelId { get; set; }
    public JObject Json { get; set; }

    public Content(string name, string slug, JObject json)
    {
        Name = name;
        Slug = slug;
        Json = json;
    }
}
