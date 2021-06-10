using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class CustomerCollectionExtensions
    {
        public static CustomerCollectionDto ToDto(this CustomerCollection customerCollection)
        {
            return new ()
            {
                CustomerCollectionId = customerCollection.CustomerCollectionId,
                CollectionId = customerCollection.CustomerId,
                CustomerCollectionType = customerCollection.CustomerCollectionType
            };
        }
    }
}
