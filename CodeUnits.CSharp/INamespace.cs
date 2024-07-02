using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface INamespace
    {
        INamespace ContainingNamespace { get; }

        string Name { get; }

        IReadOnlyList<IUsingDirective> UsingDirectives { get; }

        IReadOnlyList<INamespace> Namespaces { get; }

        IReadOnlyList<IType> Types { get; }

        IReadOnlyList<IExternAlias> ExternAliases { get; }
    }
}
