namespace CodeUnits.CSharp
{
    public sealed class UsingAliasDirectiveDefinition : UsingDirectiveDefinition
    {
        internal UsingAliasDirectiveDefinition(string value, string name, TypeUsage type)
            : base(value)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public TypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Alias;
    }
}
