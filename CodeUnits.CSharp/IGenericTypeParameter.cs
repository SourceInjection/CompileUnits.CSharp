using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a generic type parameter definition.
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters">generic type parameters</see>.
    /// </summary>
    public interface IGenericTypeParameter
    {
        /// <summary>
        /// The name of the generic type parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The defined variance of the generic type parameter.
        /// </summary>
        Variance Variance { get; }

        /// <summary>
        /// Lists the attribute groups placed before a generic type parameter.
        /// </summary>
        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        /// <summary>
        /// Lists the attributes placed over a generic type attribute.<br/>
        /// This is the same as <see cref="AttributeGroups"/>.SelectMany(ag => ag.Attributes).
        /// </summary>
        IReadOnlyList<IAttribute> Attributes { get; }
    }
}
