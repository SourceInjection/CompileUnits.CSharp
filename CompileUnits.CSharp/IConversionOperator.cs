namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents a conversion operator definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators">conversion operators</see>.
    /// </summary>
    public interface IConversionOperator : IMember
    {
        /// <summary>
        /// The kind of the conversion.
        /// </summary>
        ConversionKind Kind { get; }

        /// <summary>
        /// The single parameter of the conversion operator.
        /// </summary>
        IParameter Parameter { get; }

        /// <summary>
        /// The return type of the conversion.
        /// </summary>
        ITypeUsage ReturnType { get; }

        /// <summary>
        /// The body of the conversion.
        /// </summary>
        IBody Body { get; }
    }

    public static class IConversionOperatorExtensions
    {
        /// <summary>
        /// Checks if the conversion operator is of the desired kind.
        /// </summary>
        /// <param name="op">The operator to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the conversion operator is of the desired kind else <see langword="false"/>.</returns>
        public static bool IsKind(this IConversionOperator op, ConversionKind kind) => op.Kind == kind;
    }
}
