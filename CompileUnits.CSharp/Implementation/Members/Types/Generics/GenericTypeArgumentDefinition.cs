using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Attributes;

namespace CompileUnits.CSharp.Implementation.Members.Types.Generics
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