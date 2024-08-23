using System.Collections.Generic;

namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents the usage of attributes.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/attribute-tutorial">attribute tutorial</see>
    /// and <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/attributes">language specification</see>.
    /// </summary>
    public interface IAttribute : ITreeNode
    {
        /// <summary>
        /// The attribute group where the attribute is placed.
        /// </summary>
        IAttributeGroup ParentGroup { get;  }

        /// <summary>
        /// The type of the attribute.
        /// </summary>
        ITypeUsage Type { get; }

        /// <summary>
        /// Lists the arguments passed to the attribute.
        /// </summary>
        IReadOnlyList<IArgument> Arguments { get; }
    }
}
