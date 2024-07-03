using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="delegate"/> definition.
    /// </summary>
    public interface IDelegate : IType
    {
        /// <summary>
        /// The return type of the delegate.
        /// </summary>
        ITypeUsage ReturnType { get; }

        /// <summary>
        /// Lists the parameter definitions of the delegate.
        /// </summary>
        IReadOnlyList<IParameter> Parameters { get; }

        /// <summary>
        /// Lists the generic type arguments of the delegate.
        /// </summary>
        IReadOnlyList<IGenericTypeArgument> GenericTypeArguments { get; }

        /// <summary>
        /// Lists the type parameter constraints of the delegate.
        /// </summary>
        IReadOnlyList<IConstraint> Constraints { get; }
    }
}
