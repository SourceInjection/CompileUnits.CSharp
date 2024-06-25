
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class AttributeGroup
    {
        internal AttributeGroup(string attributeTarget, IReadOnlyList<AttributeUsage> attributes)
        {
            foreach (var attribute in attributes)
                attribute.ContainingSection = this;
            AttributeTarget = attributeTarget;
            Attributes = attributes;
        }

        public string AttributeTarget { get; } 

        public IReadOnlyList<AttributeUsage> Attributes { get; }
    }
}
