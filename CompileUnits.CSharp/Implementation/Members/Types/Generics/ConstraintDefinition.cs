using System.Collections.Generic;
namespace CompileUnits.CSharp.Implementation.Members.Types.Generics
{
    internal class ConstraintDefinition : IConstraint
    {
        internal ConstraintDefinition(GenericTypeArgumentDefinition targetedTypeArgument, IReadOnlyList<ConstraintClause> clauses)
        {
            TargetedTypeArgument = targetedTypeArgument;
            Clauses = clauses;
            foreach(var clause in clauses)
                clause.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public IGenericTypeParameter TargetedTypeArgument { get; }

        public IReadOnlyList<IConstraintClause> Clauses { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Clauses;
    }
}
