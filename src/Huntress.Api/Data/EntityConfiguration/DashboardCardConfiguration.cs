using Huntress.Api.Models;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Huntress.Api.Data
{
    public class DashboardCardConfiguration : IEntityTypeConfiguration<DashboardCard>
    {
        public void Configure(EntityTypeBuilder<DashboardCard> builder)
        {
            builder.Property(e => e.Settings).HasJsonValueConversion();
        }
    }
}
