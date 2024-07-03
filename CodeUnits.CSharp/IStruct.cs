using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="struct"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct">struct</see>.
    /// </summary>
    public interface IStruct : IStructuredType
    {
        /// <summary>
        /// If the <see langword="struct"/> has a <see langword="readonly"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsReadonly { get; }

        /// <summary>
        /// If the <see langword="struct"/> has a <see langword="record"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsRecord { get; }

        /// <summary>
        /// Lists the conversion operators within the <see langword="struct"/>.
        /// </summary>
        IReadOnlyList<IConversionOperator> ConversionOperators { get; }

        /// <summary>
        /// Lists the fields within the <see langword="struct"/>.
        /// </summary>
        IReadOnlyList<IField> Fields { get; }

        /// <summary>
        /// Lists the constructors within the <see langword="struct"/>.
        /// </summary>
        IReadOnlyList<IConstructor> Constructors { get; }
    }
}
