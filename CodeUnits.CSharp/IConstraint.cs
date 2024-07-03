using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a type parameter constraint.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters">constraints on type parameters</see>.
    /// </summary>
    public interface IConstraint
    {
        /// <summary>
        /// The targeted type argument.
        /// </summary>
        IGenericTypeParameter TargetedTypeArgument { get; }

        /// <summary>
        /// Lists all constraint causes within the type parameter constraint.
        /// </summary>
        IReadOnlyList<IConstraintClause> Clauses { get; }
    }
}
