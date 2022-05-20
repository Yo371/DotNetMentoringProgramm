using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LibraryClass.Attributes;

namespace LibraryClass.Helpers
{
    public class AttributeHelper
    {
        public static bool IsMarkedByAttribute(object obj, Type attribute)
        {
            return obj.GetType().GetCustomAttributes(false).Select(e => e.GetType())
                .Any(e => e.Equals(attribute));
        }
    }
}
