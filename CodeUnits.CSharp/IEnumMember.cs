using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a member of an <see langword="enum"/>.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum">enum</see>.
    /// </summary>
    public interface IEnumMember
    {
        /// <summary>
        /// The parent <see langword="enum"/> type.
        /// </summary>
        IEnum ContainingType { get; }

        /// <summary>
        /// The name of the member.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The value of the member.</br>
        /// This might be <see langword="null"/> if not explicitely defined.
        /// </summary>
        ICodeFragment Value { get; }

        /// <summary>
        /// The attribute groups placed over the <see langword="enum"/> member.
        /// </summary>
        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        /// <summary>
        /// Lists the attributes placed over a <see langword="enum"/> member.<br/>
        /// This is the same as <see cref="AttributeGroups"/>.SelectMany(ag => ag.Attributes).
        /// </summary>
        IReadOnlyList<IAttribute> Attributes { get; }
    }
}
