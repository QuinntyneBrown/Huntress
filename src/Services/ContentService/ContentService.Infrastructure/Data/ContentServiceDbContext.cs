// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Core;
using ContentService.Core.AggregateModel.ContentAggregate;
using ContentService.Core.AggregateModel.JsonPropertyModelAggregate;
using ContentService.Core.AggregateModel.JsonSchemaModelAggregate;
using ContentService.Core.AggregateModel.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace ContentService.Infrastructure.Data;

public class ContentServiceDbContext : DbContext, IContentServiceDbContext
{
    public ContentServiceDbContext(DbContextOptions<ContentServiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Content> Contents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<JsonSchemaModel> JsonSchemaModels { get; set; }
    public DbSet<JsonPropertyModel> JsonPropertyModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Content");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContentServiceDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
