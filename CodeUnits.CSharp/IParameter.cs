using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a parameter definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters">method parameters</see>.
    /// </summary>
    public interface IParameter
    {
        /// <summary>
        /// The type of the parameter.
        /// </summary>
        ITypeUsage Type { get; }

        /// <summary>
        /// The name of the parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The modifier of the parameter.
        /// </summary>
        ParameterModifier Modifier { get; }

        /// <summary>
        /// The attribute groups placed right before the parameter.
        /// </summary>
        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        /// <summary>
        /// Lists the attributes placed over a parameter.<br/>
        /// This is the same as <see cref="AttributeGroups"/>.SelectMany(ag => ag.Attributes).
        /// </summary>
        IReadOnlyList<IAttribute> Attributes { get; }

        /// <summary>
        /// The default value of the parameter.
        /// This might be <see langword="null"/> since declaring a default value is optional.
        /// </summary>
        ICodeFragment DefaultValue { get; }

        /// <summary>
        /// If the parameter has the <see langword="params"/> keyword followed by brackets ('[]') this is <see langword="true"/>.
        /// </summary>
        bool IsParamsArray { get; }

        /// <summary>
        /// If the parameter has a defined default value it is optional and this is <see langword="true"/>.
        /// </summary>
        bool IsOptional { get; }
    }
}
