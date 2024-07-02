using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IInvokableMember : IMember
    {
        IReadOnlyList<IParameter> Parameters { get; }

        ITypeUsage ReturnType { get; }

        ICodeFragment Body { get; }
    }
}
