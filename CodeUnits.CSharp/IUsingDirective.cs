namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a using directive.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive">using directive</see>.
    /// </summary>
    public interface IUsingDirective
    {
        /// <summary>
        /// The namespace where the using directive is defined.
        /// </summary>
        INamespace ContainingNamespace { get; }

        /// <summary>
        /// The kind of the using directive.
        /// </summary>
        UsingDirectiveKind Kind { get; }
    }

    public static class IUsingDirectiveExtensions
    {
        /// <summary>
        /// Checks if the given using directive is of the desired kind.
        /// </summary>
        /// <param name="directive">The using directive to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the using directive is of the desired kind else <see langword="false"/></returns>
        public static bool IsKind(this IUsingDirective directive, UsingDirectiveKind kind) => directive.Kind == kind;
    }
}
