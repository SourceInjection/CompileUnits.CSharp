using System.Collections.Generic;
using System.Linq;
using CompileUnits.CSharp.Implementation.Parameters;

namespace CompileUnits.CSharp.Implementation.Attributes
{
    internal class AttributeUsage : IAttribute
    {
        internal AttributeUsage(TypeUsage type, IReadOnlyList<Argument> arguments)
        {
            Type = type;
            Arguments = arguments;
            type.ParentNode = this;
            foreach (var arg in arguments)
                arg.ParentNode = this;
        }

        public IAttributeGroup ParentGroup { get; internal set; }

        public ITreeNode ParentNode => ParentGroup;

        public ITypeUsage Type { get; }

        public IReadOnlyList<IArgument> Arguments { get; }

        public IEnumerable<ITreeNode> ChildNodes()
        {
            return ((IReadOnlyList<ITreeNode>)Arguments)
                .Prepend(Type);
        }
    }
}
