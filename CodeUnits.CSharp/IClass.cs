using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see cref="class"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes">classes</see>.
    /// </summary>
    public interface IClass : IStructuredType
    {
        /// <summary>
        /// If the <see langword="class"/> has a <see langword="static"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// If the <see langword="class"/> has a <see langword="record"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsRecord { get; }

        /// <summary>
        /// If the <see langword="class"/> has a <see langword="sealed"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>
        /// If the <see langword="class"/> has a <see langword="abstract"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        /// Lists the conversion operators of the class.
        /// </summary>
        IReadOnlyList<IConversionOperator> ConversionOperators { get; }

        /// <summary>
        /// Lists the fields of the class.
        /// </summary>
        IReadOnlyList<IField> Fields { get; }

        /// <summary>
        /// Lists the constructors of the class.
        /// </summary>
        IReadOnlyList<IConstructor> Constructors { get; }

        /// <summary>
        /// Represents the finalizer of a <see langword="class"/> if defined.
        /// This might be <see langword="null"/> since finalizers are optional.
        /// </summary>
        IFinalizer Finalizer { get; }
    }
}
