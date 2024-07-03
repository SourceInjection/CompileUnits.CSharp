
using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation.Attributes
{
    internal class AttributeGroup: IAttributeGroup
    {
        internal AttributeGroup(string attributeTarget, IReadOnlyList<AttributeUsage> attributes)
        {
            foreach (var attribute in attributes)
                attribute.ParentGroup = this;
            AttributeTarget = attributeTarget;
            Attributes = attributes;
        }

        public string AttributeTarget { get; }

        public IReadOnlyList<IAttribute> Attributes { get; }
    }
}
