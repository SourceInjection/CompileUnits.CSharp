using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Parameters;

namespace CodeUnits.CSharp.Implementation.Members.Minor
{
    public sealed class ConstructorInitializer : IConstructorInitializer
    {
        public ConstructorInitializer(ConstructorInitializerKind kind, IReadOnlyList<Argument> arguments)
        {
            Kind = kind;
            Arguments = arguments;
        }

        public ConstructorInitializerKind Kind { get; }

        public IReadOnlyList<IArgument> Arguments { get; }

        public bool IsKind(ConstructorInitializerKind kind) => Kind == kind;
    }
}
