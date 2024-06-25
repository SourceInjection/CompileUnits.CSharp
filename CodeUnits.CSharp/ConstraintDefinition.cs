using System.Collections.Generic;
namespace CodeUnits.CSharp
{
    public sealed class ConstraintDefinition
    {
        internal ConstraintDefinition(IReadOnlyList<ConstraintClause> clauses)
        {
            Clauses = clauses;
        }

        public GenericTypeArgumentDefinition TargetedTypeArgument { get; internal set; }

        public IReadOnlyList<ConstraintClause> Clauses { get; }
    }
}
