// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Core.AggregateModel.ContentAggregate;
using ContentService.Core.AggregateModel.JsonPropertyModelAggregate;
using ContentService.Core.AggregateModel.JsonSchemaModelAggregate;
using ContentService.Core.AggregateModel.UserAggregate;

namespace ContentService.Core;

public interface IContentServiceDbContext
{
    DbSet<Content> Contents { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<JsonSchemaModel> JsonSchemaModels { get; set; }
    DbSet<JsonPropertyModel> JsonPropertyModels { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


