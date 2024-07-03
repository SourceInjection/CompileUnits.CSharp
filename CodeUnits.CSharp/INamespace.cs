using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="namespace"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/namespaces">namespaces</see>.
    /// </summary>
    public interface INamespace
    {
        /// <summary>
        /// The parent <see langword="namespace"/>.<br/>
        /// This might be <see langword="null"/> if the <see langword="namespace"/> is the root element (<see cref="ICodeUnit"/>).
        /// </summary>
        INamespace ContainingNamespace { get; }

        /// <summary>
        /// The name of the <see langword="namespace"/>.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Lists the using directives defined within the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<IUsingDirective> UsingDirectives { get; }

        /// <summary>
        /// Lists the <see langword="namespace"/> children defined in the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<INamespace> Namespaces { get; }

        /// <summary>
        /// Lists the type children defined in the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Lists the extern alias definition within the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<IExternAlias> ExternAliases { get; }
    }
}
