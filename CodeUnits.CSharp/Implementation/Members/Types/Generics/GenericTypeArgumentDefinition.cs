using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members.Types.Generics
{
    internal class GenericTypeArgumentDefinition : IGenericTypeArgument
    {
        internal GenericTypeArgumentDefinition(string name, Variance variance, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            Variance = variance;
            AttributeGroups = attributeGroups;
        }

        public string Name { get; }

        public Variance Variance { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }
    }
}