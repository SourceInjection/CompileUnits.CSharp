using System;
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class ConstructorDefinition : MethodDefinition
    {
        internal ConstructorDefinition(AccessModifier accessModifier, IReadOnlyList<AttributeGroup> attributeGroups, IReadOnlyList<ParameterDefinition> parameters, MethodBody body) 
            : base(string.Empty, accessModifier, false, attributeGroups, Array.Empty<string>(), parameters, 
                  null,
                  false, false, false, false, false,
                  body)
        { }

        public override MemberKind MemberKind { get; } = MemberKind.Constructor;
    }
}
