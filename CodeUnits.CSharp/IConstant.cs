namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a constant definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants">constants</see>
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
