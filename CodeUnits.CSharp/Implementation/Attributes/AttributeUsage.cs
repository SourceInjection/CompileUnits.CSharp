using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Parameters;

namespace CodeUnits.CSharp.Implementation.Attributes
{
    internal class AttributeUsage : IAttribute
    {
        internal AttributeUsage(TypeUsage type, IReadOnlyList<Argument> arguments)
        {
            Type = type;
            Arguments = arguments;
        }

        public IAttributeGroup ParentGroup { get; internal set; }

        public ITypeUsage Type { get; }

        public IReadOnlyList<IArgument> Arguments { get; }
    }
}
