// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;

namespace ContentService.Core.AggregateModel.ContentAggregate;

public class ContentDto
{
    public Guid ContentId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public JObject Json { get; set; }
}
