namespace CodeUnits.CSharp.Implementation.Usings
{
    internal class UsingAliasDirectiveDefinition : UsingDirectiveDefinition, IUsingAliasDirective
    {
        internal UsingAliasDirectiveDefinition(string name, TypeUsage type)
        {
            Alias = name;
            Type = type;
        }

        public string Alias { get; }

        public ITypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Alias;
    }
}
