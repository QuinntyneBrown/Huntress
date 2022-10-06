using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class DashboardCardExtensions
    {
        public static DashboardCardDto ToDto(this DashboardCard dashboardCard)
        {
            return new()
            {
                DashboardCardId = dashboardCard.DashboardCardId,
                CardType = dashboardCard.CardType,
                Settings = dashboardCard.Settings
            };
        }
    }
}
