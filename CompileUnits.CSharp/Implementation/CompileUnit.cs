using CompileUnits.CSharp.Implementation.Usings;
using System.Collections.Generic;

namespace CompileUnits.CSharp.Implementation
{
    internal class CompileUnit : NamespaceDefinition, ICompileUnit
    {
        internal CompileUnit(
            IReadOnlyList<UsingDirectiveDefinition> directives, 
            IReadOnlyList<INamespaceMember> members,
            IReadOnlyList<ExternAliasDefinition> externAliases)

            : base(name: string.Empty,
                  directives: directives,
                  members: members,
                  externAliases: externAliases)
        { }
    }
}
