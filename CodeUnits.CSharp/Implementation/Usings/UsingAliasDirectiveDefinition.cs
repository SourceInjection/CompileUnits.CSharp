namespace CodeUnits.CSharp.Implementation.Usings
{
    public sealed class UsingAliasDirectiveDefinition : UsingDirectiveDefinition, IUsingAliasDirective
    {
        internal UsingAliasDirectiveDefinition(string value, string name, TypeUsage type)
            : base(value)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public ITypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Alias;
    }
}
