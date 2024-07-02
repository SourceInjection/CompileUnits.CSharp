using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IEnum : IType
    {
        IReadOnlyList<IEnumMember> Members { get; }

        ITypeUsage BaseType { get; }
    }
}
