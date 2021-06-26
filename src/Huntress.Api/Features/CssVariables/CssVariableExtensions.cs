using System;
using Huntress.Api.Models;

namespace Huntress.Api.Features
{
    public static class CssVariableExtensions
    {
        public static CssVariableDto ToDto(this CssVariable cssVariable)
        {
            return new ()
            {
                CssVariableId = cssVariable.CssVariableId,
                Name = cssVariable.Name,
                Value = cssVariable.Value
            };
        }
        
    }
}
