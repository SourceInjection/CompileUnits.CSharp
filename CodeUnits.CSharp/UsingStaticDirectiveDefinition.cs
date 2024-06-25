namespace CodeUnits.CSharp
{
    public sealed class UsingStaticDirectiveDefinition: UsingDirectiveDefinition
    {
        internal UsingStaticDirectiveDefinition(string value, TypeUsage type)
            : base(value)
        {
            Type = type;
        }

        public TypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Static;
    }
}
