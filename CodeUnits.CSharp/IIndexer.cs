using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents an indexer ('[]') of a type.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/">indexers</see>.
    /// </summary>
    public interface IIndexer : IMember
    {
        /// <summary>
        /// The return type of the indexer.
        /// </summary>
        ITypeUsage ReturnType { get; }

        /// <summary>
        /// Lists all parameters of this indexer.
        /// </summary>
        IReadOnlyList<IParameter> Parameters { get; }

        /// <summary>
        /// The inheritance modifier of the indexer.
        /// </summary>
        InheritanceModifier InheritanceModifier { get; }

        /// <summary>
        /// If the indexer has a <see langword="ref"/> this is <see langword="true"/>.
        /// </summary>
        bool HasRefModifier { get; }

        /// <summary>
        /// The <see langword="get"/> accessor of the indexer.
        /// This might be <see langword="null"/> since indexers could be write only.
        /// </summary>
        IAccessor Getter { get; }

        /// <summary>
        /// The <see langword="set"/> accessor of the indexer.
        /// This might be <see langword="null"/> since indexers could be read only.
        /// </summary>
        IAccessor Setter { get; }

        /// <summary>
        /// If the indexer has a <see langword="new"/> this is <see langword="true"/>.
        /// </summary>
        bool HasNewModifier { get; }

        /// <summary>
        /// Represents the addressed interface <see langword="interface"/>.<br/>
        /// E.g.: IMyInterface.this[int i].<br/>
        /// This might be <see langword="null"/> since this is only necessary when multiple interfaces expect the same members.
        /// </summary>
        ITypeUsage AddressedInterface { get; }
    }
}
