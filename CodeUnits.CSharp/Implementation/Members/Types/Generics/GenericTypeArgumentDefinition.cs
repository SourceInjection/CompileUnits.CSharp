using System.Collections.Generic;
using System.Linq;
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
            Attributes = attributeGroups.SelectMany(ag => ag.Attributes).ToArray();
        }

        public string Name { get; }

        public Variance Variance { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<IAttribute> Attributes { get; }
    }
}