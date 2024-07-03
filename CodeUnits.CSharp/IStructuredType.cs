using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the common interface of structured types.
    /// </summary>
    public interface IStructuredType : IType
    {
        /// <summary>
        /// Lists the members within a structured type.
        /// </summary>
        IReadOnlyList<IMember> Members { get; }

        /// <summary>
        /// Lists the types within a structured type.
        /// </summary>
        IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Lists the constants within a structured type.
        /// </summary>
        IReadOnlyList<IConstant> Constants { get; }

        /// <summary>
        /// Lists the properties within a structured type.
        /// </summary>
        IReadOnlyList<IProperty> Properties { get; }

        /// <summary>
        /// Lists the methods within a structured type.
        /// </summary>
        IReadOnlyList<IMethod> Methods { get; }

        /// <summary>
        /// Lists the generic type argumetns within a structured type.
        /// </summary>
        IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        /// <summary>
        /// Lists the constraints within a structured type.
        /// </summary>
        IReadOnlyList<IConstraint> Constraints { get; }

        /// <summary>
        /// Lists the indexers within a structured type.
        /// </summary>
        IReadOnlyList<IIndexer> Indexers { get; }

        /// <summary>
        /// Lists the events within a structured type.
        /// </summary>
        IReadOnlyList<IEvent> Events { get; }

        /// <summary>
        /// Lists the operators within a structured type.
        /// </summary>
        IReadOnlyList<IOperator> Operators { get; }

        /// <summary>
        /// Lists the implemented interfaces within a structured type.
        /// </summary>
        IReadOnlyList<ITypeUsage> ImplementedInterfaces { get; }
    }
}
