using System.Collections.Generic;
namespace CodeUnits.CSharp
{
    public class ConstraintDefinition
    {
        public ConstraintDefinition(string targetedTypeArgument, IReadOnlyList<ConstraintClause> clauses)
        {
            TargetedTypeArgument = targetedTypeArgument;
            Clauses = clauses;
        }

        public string TargetedTypeArgument { get; }

        public IReadOnlyList<ConstraintClause> Clauses { get; }
    }
}
