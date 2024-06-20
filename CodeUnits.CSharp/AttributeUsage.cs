using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public class AttributeUsage
    {
        public AttributeUsage(string name, IReadOnlyList<Argument> arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public AttributeGroup ContainingSection { get; internal set; }

        public string Name { get; }

        public IReadOnlyList<Argument> Arguments { get; }
    }
}
