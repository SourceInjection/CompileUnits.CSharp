using Antlr4.Runtime;
using CodeUnits.CSharp.Implementation.Members.Types;
using CodeUnits.CSharp.Implementation.Usings;
using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation
{
    internal class CodeUnit : NamespaceDefinition, ICodeUnit
    {
        internal CodeUnit(string projectDefaultNamespace,
            IReadOnlyList<UsingDirectiveDefinition> directives, IReadOnlyList<NamespaceDefinition> namespaces,
            IReadOnlyList<TypeDefinition> types, IReadOnlyList<ExternAliasDefinition> externAliases)

            : base(name: projectDefaultNamespace,
                  directives: directives,
                  namespaces: namespaces,
                  types: types,
                  externAliases: externAliases)
        { }
    }
}
