using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class GenericValueConversion
    {
        public static T Conversion<T>(this object source)
        {
            return (T)Convert.ChangeType(source, typeof(T));

        }
    }
}
