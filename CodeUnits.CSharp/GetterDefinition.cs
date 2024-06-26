using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class GetterDefinition : AccessorDefinition
    {
        internal GetterDefinition(AccessModifier accessModifier, IReadOnlyList<AttributeGroup> attributeGroups, IReadOnlyList<AttributeUsage> attributes, Code body) 
            : base("get", accessModifier, attributeGroups, attributes, body)
        { }
    }
}
