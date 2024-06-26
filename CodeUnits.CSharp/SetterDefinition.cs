using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class SetterDefinition : AccessorDefinition
    {
        internal SetterDefinition(AccessModifier accessModifier, IReadOnlyList<AttributeGroup> attributeGroups, IReadOnlyList<AttributeUsage> attributes, Code body) 
            : base("set", accessModifier, attributeGroups, attributes, body)
        { }
    }
}
