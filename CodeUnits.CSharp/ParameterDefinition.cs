using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    public enum ParameterModifier
    {
        None,
        Ref,
        In,
        Out,
        RefThis,
        InThis,
        This,
    }

    public sealed class ParameterDefinition
    {
        internal ParameterDefinition(TypeUsage type, string name, ParameterModifier modifier, IReadOnlyList<AttributeGroup> attributes, bool isParamsArray = false, Expression defaultValue = null)
        {
            Type = type;
            Name = name;
            IsParamsArray = isParamsArray;
            DefaultValue = defaultValue;
            AttributeGroups = attributes;
            Attributes = attributes.SelectMany(a => a.Attributes).ToArray();
            IsOptional = defaultValue == null;
            Modifier = modifier;
        }

        public TypeUsage Type { get; }

        public string Name { get; }

        public ParameterModifier Modifier { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<AttributeUsage> Attributes { get; }

        public Expression DefaultValue { get; }

        public bool IsParamsArray { get; }

        public bool IsOptional { get; }
    }
}
