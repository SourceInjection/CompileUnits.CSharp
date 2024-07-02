using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IConstructorInitializer
    {
        ConstructorInitializerKind Kind { get; }

        IReadOnlyList<IArgument> Arguments { get; }
    }

    public static class IConstructorInitializerExtensions
    {
        public static bool IsKind(this IConstructorInitializer initializer, ConstructorInitializerKind kind) 
            => initializer.Kind == kind;
    }
}
