namespace CodeUnits.CSharp.Implementation.Members.Types.Generics
{
    internal class ConstraintClause : IConstraintClause
    {
        internal ConstraintClause(ConstraintKind kind, TypeUsage value = null)
        {
            Kind = kind;
            Value = value;
        }

        public ConstraintKind Kind { get; }

        public ITypeUsage Value { get; }
    }
}
