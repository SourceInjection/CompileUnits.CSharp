using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="namespace"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/namespaces">namespaces</see>.
    /// </summary>
    public interface INamespace : INamespaceMember
    {
        /// <summary>
        /// The name of the <see langword="namespace"/>.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Lists all <see langword="namespace"/> members within the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<INamespaceMember> Members { get; }

        /// <summary>
        /// Lists the using directives defined within the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<IUsingDirective> UsingDirectives { get; }

        /// <summary>
        /// Lists the extern alias definition within the <see langword="namespace"/>.
        /// </summary>
        IReadOnlyList<IExternAlias> ExternAliases { get; }
    }

    public static class INamespaceExtensions
    {
        /// <summary>
        /// Lists the type children defined in the <see langword="namespace"/>.
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        public static IEnumerable<IType> Types(this INamespace ns)
        {
            return ns.Members.OfType<IType>();
        }

        /// <summary>
        /// Lists the <see langword="namespace"/> children defined in the <see langword="namespace"/>.
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        public static IEnumerable<INamespace> Namespaces(this INamespace ns)
        {
            return ns.Members.OfType<INamespace>();
        }
    }
}
