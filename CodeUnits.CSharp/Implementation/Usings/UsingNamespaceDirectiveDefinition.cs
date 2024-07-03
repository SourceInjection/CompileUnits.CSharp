namespace CodeUnits.CSharp.Implementation.Usings
{
    internal class UsingNamespaceDirectiveDefinition : UsingDirectiveDefinition, IUsingNamespaceDirective
    {
        internal UsingNamespaceDirectiveDefinition(string @namespace)
        {
            Namespace = @namespace;
        }

        public string Namespace { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Namespace;
    }
}
