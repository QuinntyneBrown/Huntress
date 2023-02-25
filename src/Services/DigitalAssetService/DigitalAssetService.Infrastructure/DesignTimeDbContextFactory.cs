// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DigitalAssetService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microsoft.Extensions.DependencyInjection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DigitalAssetServiceDbContext>
{
    public DigitalAssetServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<DigitalAssetServiceDbContext>();

        builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Huntress;Integrated Security=SSPI;");

        return new DigitalAssetServiceDbContext(builder.Options);
    }
}