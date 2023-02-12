﻿// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContentService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microsoft.Extensions.DependencyInjection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContentServiceDbContext>
{
    public ContentServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ContentServiceDbContext>();

        builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Huntress;Integrated Security=SSPI;");

        return new ContentServiceDbContext(builder.Options);
    }
}