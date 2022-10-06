using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Services
{
    public class StripeClient : IStripeClient
    {
        public async Task<Charge> Charge(long cost, string number, long expYear, long expMonth, string cvc, string description, CancellationToken cancellationToken)
        {
            var optionsToken = new TokenCreateOptions()
            {
                Card = new AnyOf<string, TokenCardOptions>(new TokenCardOptions
                {
                    Number = number,
                    ExpYear = $"{expYear}",
                    ExpMonth = $"{expMonth}",
                    Cvc = cvc
                })
            };

            var serviceToken = new TokenService();

            var stripeToken = await serviceToken.CreateAsync(optionsToken, cancellationToken: cancellationToken);

            var options = new ChargeCreateOptions
            {
                Amount = cost,
                Currency = Constants.Currency.CDN,
                Description = description,
                Source = stripeToken.Id
            };

            var service = new ChargeService();

            return await service.CreateAsync(options, cancellationToken: cancellationToken);
        }
    }
}
