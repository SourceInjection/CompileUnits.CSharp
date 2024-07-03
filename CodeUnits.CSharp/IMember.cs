using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a member of a structured type.<br/>
    /// Types, properties, fields, methods, destructors, constructors, operators, conversion operators, indexers, events and constants are members.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members">members</see>
    /// </summary>
    public interface IMember
    {
        /// <summary>
        /// The kind of the member.
        /// </summary>
        MemberKind MemberKind { get; }

        /// <summary>
        /// Lists the attribute groups placed right before a member.
        /// </summary>
        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        /// <summary>
        /// Lists the attributes placed over a member.<br/>
        /// This is the same as <see cref="AttributeGroups"/>.SelectMany(ag => ag.Attributes).
        /// </summary>
        IReadOnlyList<IAttribute> Attributes { get; }

        /// <summary>
        /// The parent type where the member is defined.
        /// This might be <see langword="null"/> if the member is a structured type.
        /// </summary>
        IType ContainingType { get; }

        /// <summary>
        /// The name of the member.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The access modifier of the member.
        /// </summary>
        AccessModifier AccessModifier { get; }
    }

    public static class IMemberExtensions
    {
        /// <summary>
        /// Checks if the member is of the desired kind.
        /// </summary>
        /// <param name="member">The member to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the member is of the desired kind else <see langword="false"/>.</returns>
        public static bool IsKind(this IMember member, MemberKind kind) => member.MemberKind == kind;

        /// <summary>
        /// Checks if the member has the desired accessibility.
        /// </summary>
        /// <param name="member">The member to be checked.</param>
        /// <param name="kind">The desired accessibility.</param>
        /// <returns><see langword="true"/> if the member has the desired accessibility else <see langword="false"/>.</returns>
        public static bool HasAccessibility(this IMember member, AccessModifier modifier) => member.AccessModifier == modifier;
    }
}
