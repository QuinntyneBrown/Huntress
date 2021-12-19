using Huntress.Api.Models;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Huntress.Api.Data
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(content => content.Json).HasJsonValueConversion();
        }
    }
}
