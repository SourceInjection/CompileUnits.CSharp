namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the common <see langword="interface"/> of type definitions.
    /// </summary>
    public interface IType : IMember
    {
        /// <summary>
        /// The kind of the type.
        /// </summary>
        TypeKind TypeKind { get; }

        /// <summary>
        /// The parent <see langword="namespace"/> where the type is defined.
        /// </summary>
        INamespace ContainingNamespace { get; }

        /// <summary>
        /// If the type has a <see langword="new"/> modifier this is <see langword="true"/>
        /// </summary>
        bool HasNewModifier { get; }
    }
}
