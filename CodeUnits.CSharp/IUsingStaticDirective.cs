namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a static using directive.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive">using directive</see>.
    /// </summary>
    public interface IUsingStaticDirective : IUsingDirective
    {
        /// <summary>
        /// The type which is imported.
        /// </summary>
        ITypeUsage Type { get; }
    }
}
