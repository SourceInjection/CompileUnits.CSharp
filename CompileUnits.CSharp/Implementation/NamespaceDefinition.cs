using System.Collections.Generic;
using System.Linq;
using CompileUnits.CSharp.Implementation.Members.Types;
using CompileUnits.CSharp.Implementation.Usings;

namespace CompileUnits.CSharp.Implementation
{
    internal class NamespaceDefinition : INamespace
    {
        internal NamespaceDefinition(
            string name,
            IReadOnlyList<UsingDirectiveDefinition> directives,
            IReadOnlyList<INamespaceMember> members,
            IReadOnlyList<ExternAliasDefinition> externAliases)
        {
            Name = name;
            Members = members;
            foreach (var ns in members.OfType<NamespaceDefinition>())
                ns.ContainingNamespace = this;
            foreach (var type in members.OfType<TypeDefinition>())
                type.ContainingNamespace = this;
            foreach (var directive in directives)
                directive.ContainingNamespace = this;
            UsingDirectives = directives;
            foreach (var alias in externAliases)
                alias.ContainingNamespace = this;
            ExternAliases = externAliases;
        }

        public INamespace ContainingNamespace { get; internal set; }

        public ITreeNode ParentNode => ContainingNamespace;

        public string Name { get; }

        public IReadOnlyList<INamespaceMember> Members { get; }

        public IReadOnlyList<IUsingDirective> UsingDirectives { get; }

        public IReadOnlyList<IExternAlias> ExternAliases { get; }

        public NamespaceMemberKind NamespaceMemberKind { get; } = NamespaceMemberKind.Namespace;

        public IEnumerable<ITreeNode> ChildNodes()
        {
            return ((IReadOnlyList<ITreeNode>)ExternAliases)
                .Concat(UsingDirectives)
                .Concat(Members);
        }
    }
}
