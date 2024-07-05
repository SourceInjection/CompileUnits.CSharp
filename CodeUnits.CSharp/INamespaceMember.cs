namespace CodeUnits.CSharp
{
    public interface INamespaceMember
    {
        /// <summary>
        /// The parent <see langword="namespace"/> where the namespace member is defined.
        /// </summary>
        INamespace ContainingNamespace { get; }

        /// <summary>
        /// The kind of the namespace member.
        /// </summary>
        NamespaceMemberKind NamespaceMemberKind { get; }
    }

    public static class INamespaceMemberExtensions
    {
        /// <summary>
        /// Checks if the namespace member is of the desired kind.
        /// </summary>
        /// <param name="member">The namespace member to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the namespace member is of the desired kind else <see langword="false"/>.</returns>
        public static bool IsKind(this INamespaceMember member, NamespaceMemberKind kind) 
            => member.NamespaceMemberKind == kind;
    }
}
