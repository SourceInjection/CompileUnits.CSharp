namespace CodeUnits.CSharp
{
    public interface IUsingDirective
    {
        INamespace ContainingNamespace { get; }

        string Value { get; }

        UsingDirectiveKind Kind { get; }
    }

    public static class IUsingDirectiveExtensions
    {
        public static bool IsKind(this IUsingDirective directive, UsingDirectiveKind kind) => directive.Kind == kind;
    }
}
