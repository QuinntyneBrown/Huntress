using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace Huntress.Api.Services
{
    public interface IStripeClient
    {
        Task<Charge> Charge(long cost, string number, long expYear, long expMonth, string cvc, string description, CancellationToken cancellationToken);
    }
}
