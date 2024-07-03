namespace CodeUnits.CSharp
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
        ICodeFragment Body { get; }
    }

    public static class IConversionOperatorExtensions
    {
        public static bool IsKind(this IConversionOperator op, ConversionKind kind) => op.Kind == kind;
    }
}
