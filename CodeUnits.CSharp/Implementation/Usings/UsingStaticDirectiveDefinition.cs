namespace CodeUnits.CSharp.Implementation.Usings
{
    public sealed class UsingStaticDirectiveDefinition : UsingDirectiveDefinition, IUsingStaticDirective
    {
        internal UsingStaticDirectiveDefinition(string value, TypeUsage type)
            : base(value)
        {
            Type = type;
        }

        public ITypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Static;
    }
}
