using System.Collections.Generic;

namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents the definition of an <see langword="enum"/>.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum">enum</see>.
    /// </summary>
    public interface IEnum : IType
    {
        /// <summary>
        /// The members of the <see langword="enum"/>.
        /// </summary>
        IReadOnlyList<IEnumMember> Members { get; }

        /// <summary>
        /// The base type of the <see langword="enum"/>.<br/>
        /// This might be <see langword="null"/> if not declared explicitely.
        /// </summary>
        ITypeUsage BaseType { get; }
    }
}
