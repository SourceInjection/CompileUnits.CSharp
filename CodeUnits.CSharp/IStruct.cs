using CodeUnits.CSharp.Implementation;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="struct"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct">struct</see>.
    /// </summary>
    public interface IStruct : IInstanceable
    {
        /// <summary>
        /// If the <see langword="struct"/> has a <see langword="readonly"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsReadonly { get; }

        /// <summary>
        /// If the <see langword="struct"/> has a <see langword="record"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsRecord { get; }
    }
}
