using CodeUnits.CSharp.Implementation.Usings;
using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation
{
    internal class CodeUnit : NamespaceDefinition, ICodeUnit
    {
        internal CodeUnit(string projectDefaultNamespace,
            IReadOnlyList<UsingDirectiveDefinition> directives, 
            IReadOnlyList<INamespaceMember> members,
            IReadOnlyList<ExternAliasDefinition> externAliases)

            : base(name: projectDefaultNamespace,
                  directives: directives,
                  members: members,
                  externAliases: externAliases)
        { }
    }
}
