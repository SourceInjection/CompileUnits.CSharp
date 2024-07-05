namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the common <see langword="interface"/> of type definitions.
    /// </summary>
    public interface IType : IMember, INamespaceMember
    {
        /// <summary>
        /// The kind of the type.
        /// </summary>
        TypeKind TypeKind { get; }

        /// <summary>
        /// If the type has a <see langword="new"/> modifier this is <see langword="true"/>
        /// </summary>
        bool HasNewModifier { get; }
    }
}
