using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp.Implementation
{
    internal class ExternAliasDefinition : IExternAlias
    {
        internal ExternAliasDefinition(string name)
        {
            Name = name;
        }

        public INamespace ContainingNamespace { get; internal set; }

        public ITreeNode ParentNode => ContainingNamespace;

        public string Name { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Enumerable.Empty<ITreeNode>();
    }
}
