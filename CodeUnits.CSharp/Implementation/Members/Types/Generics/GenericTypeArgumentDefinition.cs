using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members.Types.Generics
{
    internal class GenericTypeArgumentDefinition : IGenericTypeParameter
    {
        internal GenericTypeArgumentDefinition(string name, Variance variance, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            Variance = variance;
            AttributeGroups = attributeGroups;
            foreach(var attr in attributeGroups)
                attr.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public string Name { get; }

        public Variance Variance { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public IEnumerable<ITreeNode> ChildNodes() => AttributeGroups;
    }
}