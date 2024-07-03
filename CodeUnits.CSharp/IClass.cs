namespace CodeUnits.CSharp
{
    public interface IClass : IStructuredType
    {
        /// <summary>
        /// If the <see langword="class"/> has the <see langword="static"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// If the <see langword="class"/> has the <see langword="record"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsRecord { get; }

        /// <summary>
        /// If the <see langword="class"/> has the <see langword="sealed"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>
        /// If the <see langword="class"/> has the <see langword="abstract"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        /// Represents the destructor of a <see langword="class"/> if defined.
        /// This might be <see langword="null"/> since destructors are optional.
        /// </summary>
        IDestructor Destructor { get; }
    }
}
