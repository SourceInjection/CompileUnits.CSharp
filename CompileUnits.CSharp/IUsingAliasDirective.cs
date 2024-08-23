namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents an alias using directive.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive">using directive</see>.
    /// </summary>
    public interface IUsingAliasDirective : IUsingDirective
    {
        /// <summary>
        /// The alias name.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// The type for which the alias is defined.
        /// </summary>
        ITypeUsage Type { get; }
    }
}
