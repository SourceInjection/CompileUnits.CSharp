using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IConstraint
    {
        IGenericTypeArgument TargetedTypeArgument { get; }

        IReadOnlyList<IConstraintClause> Clauses { get; }
    }
}
