// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DashboardService.Core;
using Microsoft.EntityFrameworkCore;

namespace DashboardService.Infrastructure.Data;

public class DashboardServiceDbContext: DbContext, IDashboardServiceDbContext
{
    public DashboardServiceDbContext(DbContextOptions<DashboardServiceDbContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Dashboard");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<CardLayout> CardLayouts { get; set; }
    public DbSet<Dashboard> Dashboards { get; set; }
    public DbSet<DashboardCard> DashboardCards { get; set; }
    public DbSet<User> Users { get; set; }
}


