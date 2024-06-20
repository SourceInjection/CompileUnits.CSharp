using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public enum Variance { None, In, Out }

    public class GenericTypeArgumentDefinition
    {
        public GenericTypeArgumentDefinition(string name, Variance variance, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            Variance = variance;
            AttributeGroups = attributeGroups;
        }

        public string Name { get; }

        public Variance Variance { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }
    }
}