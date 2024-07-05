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
            foreach (var arg in arguments)
                arg.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public ConstructorInitializerKind Kind { get; }

        public IReadOnlyList<IArgument> Arguments { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Arguments;
    }
}
