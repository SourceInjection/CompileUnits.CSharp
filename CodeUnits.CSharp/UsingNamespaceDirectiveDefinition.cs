namespace CodeUnits.CSharp
{
    public sealed class UsingNamespaceDirectiveDefinition: UsingDirectiveDefinition
    {
        internal UsingNamespaceDirectiveDefinition(string value, string @namespace)
            : base(value)
        {
            Namespace = @namespace;
        }

        public string Namespace { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Namespace;
    }
}
