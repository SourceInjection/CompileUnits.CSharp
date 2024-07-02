
using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation.Attributes
{
    internal class AttributeGroup: IAttributeGroup
    {
        internal AttributeGroup(string attributeTarget, IReadOnlyList<AttributeUsage> attributes)
        {
            foreach (var attribute in attributes)
                attribute.ContainingSection = this;
            AttributeTarget = attributeTarget;
            Attributes = attributes;
        }

        public string AttributeTarget { get; }

        public IReadOnlyList<IAttributeUsage> Attributes { get; }
    }
}
