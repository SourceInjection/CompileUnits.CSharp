using System;
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class DestructorDefinition : MethodDefinition
    {
        internal DestructorDefinition(IReadOnlyList<AttributeGroup> attributeGroups, MethodBody body) 
            : base("~", AccessModifier.None, false, attributeGroups, 
                  Array.Empty<string>(), 
                  Array.Empty<ParameterDefinition>(), 
                  TypeUsage.Void, 
                  false, false, false, false, false,
                  body)
        { }

        public override MemberKind MemberKind { get; } = MemberKind.Destructor;
    }
}
