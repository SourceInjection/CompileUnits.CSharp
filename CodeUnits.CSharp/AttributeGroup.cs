
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public class AttributeGroup
    {
        public AttributeGroup(string attributeTarget, IReadOnlyList<AttributeUsage> attributes)
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
