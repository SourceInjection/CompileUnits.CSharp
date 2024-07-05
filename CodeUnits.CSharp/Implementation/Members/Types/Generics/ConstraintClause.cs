using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation.Members.Types.Generics
{
    internal class ConstraintClause : IConstraintClause
    {
        internal ConstraintClause(ConstraintKind kind, TypeUsage value = null)
        {
            Kind = kind;
            Value = value;
            if(value != null)
                value.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public ConstraintKind Kind { get; }

        public ITypeUsage Value { get; }

        public IEnumerable<ITreeNode> ChildNodes()
        {
            if (Value != null)
                yield return Value;
        }
    }
}
