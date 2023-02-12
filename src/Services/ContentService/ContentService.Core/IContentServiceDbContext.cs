// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Core.AggregateModel.ContentAggregate;
using ContentService.Core.AggregateModel.UserAggregate;

namespace ContentService.Core;

public interface IContentServiceDbContext
{
    DbSet<Content> Contents { get; set; }
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


