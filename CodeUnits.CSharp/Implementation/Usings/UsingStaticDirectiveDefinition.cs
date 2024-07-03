namespace CodeUnits.CSharp.Implementation.Usings
{
    internal class UsingStaticDirectiveDefinition : UsingDirectiveDefinition, IUsingStaticDirective
    {
        internal UsingStaticDirectiveDefinition(TypeUsage type)
        {
            Type = type;
        }

        public ITypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Static;
    }
}
