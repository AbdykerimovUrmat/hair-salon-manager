using System;

namespace HairSalon.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this Object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this Object obj)
        {
            return !IsNull(obj);
        }
    }
}
