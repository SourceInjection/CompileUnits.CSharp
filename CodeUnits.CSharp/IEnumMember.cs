namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a member of an <see langword="enum"/>.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum">enum</see>.
    /// </summary>
    public interface IEnumMember : IAttributeable
    {
        /// <summary>
        /// The parent <see langword="enum"/> type.
        /// </summary>
        IEnum ContainingType { get; }

        /// <summary>
        /// The name of the member.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The value of the member.</br>
        /// This might be <see langword="null"/> if not explicitely defined.
        /// </summary>
        IExpression Value { get; }
    }
}
