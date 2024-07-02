using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Members.Types;
using CodeUnits.CSharp.Implementation.Usings;

namespace CodeUnits.CSharp.Implementation
{
    internal class NamespaceDefinition : INamespace
    {
        internal NamespaceDefinition(
            string name,
            IReadOnlyList<UsingDirectiveDefinition> directives,
            IReadOnlyList<NamespaceDefinition> namespaces,
            IReadOnlyList<TypeDefinition> types,
            IReadOnlyList<ExternAliasDefinition> externAliases)
        {
            Name = name;
            foreach (var ns in namespaces)
                ns.ContainingNamespace = this;
            Namespaces = namespaces;
            foreach (var type in types)
                type.ContainingNamespace = this;
            Types = types;
            foreach (var directive in directives)
                directive.ContainingNamespace = this;
            UsingDirectives = directives;
            foreach (var alias in externAliases)
                alias.ContainingNamespace = this;
            ExternAliases = externAliases;
        }

        public INamespace ContainingNamespace { get; internal set; }

        public string Name { get; }

        public IReadOnlyList<IUsingDirective> UsingDirectives { get; }

        public IReadOnlyList<INamespace> Namespaces { get; }

        public IReadOnlyList<IType> Types { get; }

        public IReadOnlyList<IExternAlias> ExternAliases { get; }
    }
}
