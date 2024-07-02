namespace CodeUnits.CSharp
{
    public interface IConversionOperator : IMember
    {
        ConversionKind Kind { get; }

        IParameter Parameter { get; }

        ITypeUsage ReturnType { get; }

        ICodeFragment Body { get; }
    }

    public static class IConversionOperatorExtensions
    {
        public static bool IsKind(this IConversionOperator op, ConversionKind kind) => op.Kind == kind;
    }
}
