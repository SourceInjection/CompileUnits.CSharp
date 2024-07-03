using System.Collections.Generic;
namespace CodeUnits.CSharp.Implementation.Members.Types.Generics
{
    internal class ConstraintDefinition : IConstraint
    {
        internal ConstraintDefinition(GenericTypeArgumentDefinition targetedTypeArgument, IReadOnlyList<ConstraintClause> clauses)
        {
            TargetedTypeArgument = targetedTypeArgument;
            Clauses = clauses;
        }

        public IGenericTypeParameter TargetedTypeArgument { get; }

        public IReadOnlyList<IConstraintClause> Clauses { get; }
    }
}
