using System.Collections.Generic;

namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="delegate"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/">delegates</see>.
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
        IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        /// <summary>
        /// Lists the type parameter constraints of the delegate.
        /// </summary>
        IReadOnlyList<IConstraint> Constraints { get; }
    }
}
