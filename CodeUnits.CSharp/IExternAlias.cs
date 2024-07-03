namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents an <see langword="extern"/> <see langword="alias"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias">extern alias</see>.
    /// </summary>
    public interface IExternAlias
    {
        /// <summary>
        /// The containing namespace where the <see langword="extern"/> <see langword="alias"/> is defined.
        /// </summary>
        INamespace ContainingNamespace { get; }

        /// <summary>
        /// The name of the <see langword="extern"/> <see langword="alias"/>.
        /// </summary>
        string Name { get; }
    }
}
