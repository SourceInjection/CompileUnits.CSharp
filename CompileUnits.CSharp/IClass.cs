using System.Linq;

namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents a <see cref="class"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes">classes</see>.
    /// </summary>
    public interface IClass : IInstanceable
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
        /// The finalizer of the class.
        /// This might be <see langword="null"/> since finalizers are optional.
        /// </summary>
        IFinalizer Finalizer { get; }
    }

    public static class IClassExtension
    {
        /// <summary>
        /// Represents the finalizer of a <see langword="class"/> if defined.
        /// This might be <see langword="null"/> since finalizers are optional.
        /// </summary>
        /// <param name="class"></param>
        /// <returns>The finalizer if defined else <see langword="null"/>.</returns>
        public static IFinalizer Finalizer(this IClass @class)
        {
            return @class.Members.OfType<IFinalizer>().FirstOrDefault();
        }
    }
}
