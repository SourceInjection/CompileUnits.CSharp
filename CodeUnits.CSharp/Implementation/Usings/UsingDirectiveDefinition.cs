using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp.Implementation.Usings
{
    internal abstract class UsingDirectiveDefinition : IUsingDirective
    {
        public ITreeNode ParentNode => ContainingNamespace;

        public INamespace ContainingNamespace { get; internal set; }

        public abstract UsingDirectiveKind Kind { get; }

        public virtual IEnumerable<ITreeNode> ChildNodes() => Enumerable.Empty<ITreeNode>();
    }
}
