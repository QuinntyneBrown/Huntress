using System.Collections.Generic;

namespace Huntress.Api.Core
{
    public class PaginatedResponse<TEntity> : ResponseBase
    {
        public int Index { get; private set; }
        public int Length { get; private set; }
        public IEnumerable<TEntity> Data { get; private set; }

        public PaginatedResponse(int index, int length, IEnumerable<TEntity> data)
        {
            Index = index;
            Length = length;
            Data = data;
        }
    }
}
