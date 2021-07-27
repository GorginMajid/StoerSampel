using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSampel.Common
{
    public static class ObjectExtensions
    {
        public static void CheckArgumentIsNull(this object o, string name)
        {
            if (o == null)
                throw new ArgumentNullException(name);
        }
    }
}
