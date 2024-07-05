using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation
{
    internal static class TypeUsages
    {
        public static IEnumerable<TypeUsage> FromContext(Interface_type_listContext context)
        {
            if (context == null)
                yield break;

            foreach (var c in context.namespace_or_type_name())
                yield return TypeUsage.FromContext(c);
        }

        public static IEnumerable<TypeUsage> FromContext(Class_baseContext context)
        {
            if(context == null) 
                yield break;

            if(context.class_type() != null)
                yield return TypeUsage.FromContext(context.class_type());

            if (context.namespace_or_type_name() == null)
                yield break;

            foreach(var c in context.namespace_or_type_name())
                yield return TypeUsage.FromContext(c);
        }

        public static IEnumerable<TypeUsage> FromContext(Struct_interfacesContext context)
        {
            if(context?.interface_type_list()?.namespace_or_type_name() == null)
                yield break;

            foreach(var c in context.interface_type_list().namespace_or_type_name())
                yield return TypeUsage.FromContext(c);
        }
    }
}
