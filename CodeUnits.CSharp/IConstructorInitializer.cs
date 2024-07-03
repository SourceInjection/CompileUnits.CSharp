using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the initializer of a constructor.
    /// E.g.: base(arg1, arg2) or this(arg1, arg2).<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors">constructors</see>.
    /// </summary>
    public interface IConstructorInitializer
    {
        /// <summary>
        /// The constructor initializer kind.
        /// </summary>
        ConstructorInitializerKind Kind { get; }

        /// <summary>
        /// Lists the arguments passed within the initializer.
        /// </summary>
        IReadOnlyList<IArgument> Arguments { get; }
    }

    public static class IConstructorInitializerExtensions
    {
        /// <summary>
        /// Checks if the constructor initializer is of the desired kind.
        /// </summary>
        /// <param name="initializer">The constructor initializer to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the constructor initializer is of the desired kind else <see langword="false"/></returns>
        public static bool IsKind(this IConstructorInitializer initializer, ConstructorInitializerKind kind) 
            => initializer.Kind == kind;
    }
}
