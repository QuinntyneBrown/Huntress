using Newtonsoft.Json.Linq;
using System;

namespace Huntress.Api.Models
{
    public class DashboardCard
    {
        public Guid DashboardCardId { get; private set; }
        public string CardType { get; private set; }
        public JObject Settings { get; private set; }

        public DashboardCard(string cardType, JObject settings)
        {
            CardType = cardType;
            Settings = settings;
        }

        private DashboardCard()
        {

        }

        public void UpdateSettings(JObject settings)
        {
            Settings = settings;
        }

        public void UpdateCardType(string cardType)
        {
            CardType = cardType;
        }
    }
}
