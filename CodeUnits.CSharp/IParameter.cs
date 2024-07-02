using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IParameter
    {
        ITypeUsage Type { get; }

        string Name { get; }

        ParameterModifier Modifier { get; }

        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        IReadOnlyList<IAttributeUsage> Attributes { get; }

        ICodeFragment DefaultValue { get; }

        bool IsParamsArray { get; }

        bool IsOptional { get; }
    }
}
