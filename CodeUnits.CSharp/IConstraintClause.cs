namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a constraint clause within a constraint.
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters">constraints on type parameters</see>.
    /// </summary>
    public interface IConstraintClause
    {
        /// <summary>
        /// The kind of the constraint clause.
        /// </summary>
        ConstraintKind Kind { get; }

        /// <summary>
        /// If the constraint kind is <see cref="ConstraintKind.OfType"/> this value represents the type.<br/>
        /// Otherwhise this is always <see langword="null"/>.
        /// </summary>
        ITypeUsage Value { get; }
    }

    public static class IConstaintClauseExtensions
    {
        /// <summary>
        /// Checks if the constraint clause is of the desired kind.
        /// </summary>
        /// <param name="clause">The constraint clause to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the constraint clause is of the desired kind else <see langword="false"/>.</returns>
        public static bool IsKind(this IConstraintClause clause, ConstraintKind kind) => clause.Kind == kind;
    }
}
