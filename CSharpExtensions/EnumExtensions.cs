using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumUtilities
{
    public static class EnumExtensions
    {
        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            return
                Enum.GetValues(input.GetType())
                .Cast<Enum>()
                .Where(input.HasFlag);
        }
    }
}
