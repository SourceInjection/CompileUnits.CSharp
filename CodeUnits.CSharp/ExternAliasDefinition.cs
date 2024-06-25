namespace CodeUnits.CSharp
{
    public sealed class ExternAliasDefinition
    {
        internal ExternAliasDefinition(string name)
        {
            Name = name;
        }

        public NamespaceDefinition ContainingNamespace { get; internal set; }

        public string Name { get; }
    }
}
