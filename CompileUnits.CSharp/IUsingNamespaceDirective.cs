namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents a namespace using directive.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive">using directive</see>.
    /// </summary>
    public interface IUsingNamespaceDirective : IUsingDirective
    {
        /// <summary>
        /// The namespace which is imported.
        /// </summary>
        string Namespace { get; }
    }
}
