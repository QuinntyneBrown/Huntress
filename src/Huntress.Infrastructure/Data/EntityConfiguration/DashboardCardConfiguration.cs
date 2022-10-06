using Huntress.Domain.Entities;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Huntress.Infrastructure.Data
{
    public class DashboardCardConfiguration : IEntityTypeConfiguration<DashboardCard>
    {
        public void Configure(EntityTypeBuilder<DashboardCard> builder)
        {
            builder.Property(e => e.Settings).HasJsonValueConversion();
        }
    }
}
