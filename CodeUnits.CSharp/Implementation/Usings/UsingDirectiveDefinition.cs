namespace CodeUnits.CSharp.Implementation.Usings
{
    internal abstract class UsingDirectiveDefinition : IUsingDirective
    {
        public INamespace ContainingNamespace { get; internal set; }

        public abstract UsingDirectiveKind Kind { get; }
    }
}
