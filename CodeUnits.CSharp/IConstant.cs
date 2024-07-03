namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a constant definition.
    /// </summary>
    public interface IConstant : IMember
    {
        /// <summary>
        /// The type of a constant.
        /// </summary>
        ITypeUsage Type { get; }

        /// <summary>
        /// The value of a constant.
        /// </summary>
        ICodeFragment Value { get; }

        /// <summary>
        /// If the constant has a <see langword="new"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool HasNewModifier { get; }
    }
}
