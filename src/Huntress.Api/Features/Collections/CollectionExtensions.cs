using Huntress.Api.Models;
using System.Linq;

namespace Huntress.Api.Features
{
    public static class CollectionExtensions
    {
        public static CollectionDto ToDto(this Collection collection)
        {
            return new()
            {
                CollectionId = collection.CollectionId,
                CollectionType = collection.CollectionType,
                CollectionItems = collection.CollectionItems.Select(x => x.ToDto()).ToList()
            };
        }

    }
}
