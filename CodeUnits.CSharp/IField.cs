namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a field definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields">fields</see>.
    /// </summary>
    public interface IField : IMember
    {
        /// <summary>
        /// The type of the field.
        /// </summary>
        ITypeUsage Type { get; }

        /// <summary>
        /// If the field has a <see langword="static"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// If the field has a <see langword="readonly"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsReadonly { get; }

        /// <summary>
        /// If the field has a <see langword="new"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool HasNewModifier { get; }

        /// <summary>
        /// The initialization of the field.
        /// </summary>
        ICodeFragment Initialization { get; }
    }
}
