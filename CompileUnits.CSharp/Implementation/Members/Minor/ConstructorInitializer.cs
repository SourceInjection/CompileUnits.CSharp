using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Parameters;

namespace CompileUnits.CSharp.Implementation.Members.Minor
{
    internal class ConstructorInitializer : IConstructorInitializer
    {
        public ConstructorInitializer(ConstructorInitializerKind kind, IReadOnlyList<Argument> arguments)
        {
            Kind = kind;
            Arguments = arguments;
            foreach (var arg in arguments)
                arg.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public ConstructorInitializerKind Kind { get; }

        public IReadOnlyList<IArgument> Arguments { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Arguments;
    }
}
