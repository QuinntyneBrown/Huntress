using System;
using Huntress.Domain.Entities;

namespace Huntress.Api.Features
{
    public static class ThemeExtensions
    {
        public static ThemeDto ToDto(this Theme theme)
        {
            return new ()
            {
                ThemeId = theme.ThemeId
            };
        }
        
    }
}
