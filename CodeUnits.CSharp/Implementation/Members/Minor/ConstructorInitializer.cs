using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Parameters;

namespace CodeUnits.CSharp.Implementation.Members.Minor
{
    internal class ConstructorInitializer : IConstructorInitializer
    {
        public ConstructorInitializer(ConstructorInitializerKind kind, IReadOnlyList<Argument> arguments)
        {
            Kind = kind;
            Arguments = arguments;
        }

        public ConstructorInitializerKind Kind { get; }

        public IReadOnlyList<IArgument> Arguments { get; }
    }
}
