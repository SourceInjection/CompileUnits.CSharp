
using System.Collections.Generic;

namespace CompileUnits.CSharp.Implementation.Attributes
{
    internal class AttributeGroup: IAttributeGroup
    {
        internal AttributeGroup(string attributeTarget, IReadOnlyList<AttributeUsage> attributes)
        {
            AttributeTarget = attributeTarget;
            Attributes = attributes;
            foreach (var attribute in attributes)
                attribute.ParentGroup = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public string AttributeTarget { get; }

        public IReadOnlyList<IAttribute> Attributes { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Attributes;
    }
}
