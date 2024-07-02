using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Destructor
    {
        public static DestructorDefinition FromContext(Destructor_definitionContext context, List<AttributeGroup> attributeGroups)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));
            return new DestructorDefinition(attributeGroups, new Code(context.body().block()));
        }
    }
}
