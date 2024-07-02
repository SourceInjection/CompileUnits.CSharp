namespace CodeUnits.CSharp.Implementation
{
    internal class ExternAliasDefinition : IExternAlias
    {
        internal ExternAliasDefinition(string name)
        {
            Name = name;
        }

        public INamespace ContainingNamespace { get; internal set; }

        public string Name { get; }
    }
}
