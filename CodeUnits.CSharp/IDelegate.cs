using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IDelegate : IType
    {
        ITypeUsage ReturnType { get; }

        IReadOnlyList<IParameter> Parameters { get; }

        IReadOnlyList<IGenericTypeArgument> GenericTypeArguments { get; }

        IReadOnlyList<IConstraint> Constraints { get; }
    }
}
