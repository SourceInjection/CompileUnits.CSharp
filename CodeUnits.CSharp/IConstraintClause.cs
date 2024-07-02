namespace CodeUnits.CSharp
{
    public interface IConstraintClause
    {
        ConstraintKind Kind { get; }

        ITypeUsage Value { get; }
    }

    public static class IConstaintClauseExtensions
    {
        public static bool IsKind(this IConstraintClause clause, ConstraintKind kind) => clause.Kind == kind;
    }
}
