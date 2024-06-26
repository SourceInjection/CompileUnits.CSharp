using System;
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class DestructorDefinition : InvokableMemberDefinition
    {
        internal DestructorDefinition(IReadOnlyList<AttributeGroup> attributeGroups, Code body) 
            : base(
                  "~", 
                  AccessModifier.None, 
                  attributeGroups, 
                  TypeUsage.Void, 
                  Array.Empty<ParameterDefinition>(), 
                  body)
        { }

        public override MemberKind MemberKind { get; } = MemberKind.Destructor;
    }
}
