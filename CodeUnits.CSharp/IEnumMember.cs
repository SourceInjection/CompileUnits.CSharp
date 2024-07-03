using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a member of an <see langword="enum"/>.
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
    }
}
