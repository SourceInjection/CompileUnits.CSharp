using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class AttributeUsage
    {
        internal AttributeUsage(string name, IReadOnlyList<Argument> arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public AttributeGroup ContainingSection { get; internal set; }

        public string Name { get; }

        public IReadOnlyList<Argument> Arguments { get; }
    }
}
