namespace CodeUnits.CSharp.Implementation.Usings
{
    internal class UsingNamespaceDirectiveDefinition : UsingDirectiveDefinition, IUsingNamespaceDirective
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
