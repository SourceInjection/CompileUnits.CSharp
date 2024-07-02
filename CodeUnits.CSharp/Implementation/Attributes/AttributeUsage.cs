using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Parameters;

namespace CodeUnits.CSharp.Implementation.Attributes
{
    internal class AttributeUsage : IAttributeUsage
    {
        internal AttributeUsage(string name, IReadOnlyList<Argument> arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public IAttributeGroup ContainingSection { get; internal set; }

        public string Name { get; }

        public IReadOnlyList<IArgument> Arguments { get; }
    }
}
