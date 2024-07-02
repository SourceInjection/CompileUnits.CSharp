using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IStructuredType : IType
    {
        IReadOnlyList<IMember> Members { get; }

        IReadOnlyList<IType> Types { get; }

        IReadOnlyList<IConstant> Constants { get; }

        IReadOnlyList<IField> Fields { get; }

        IReadOnlyList<IConstructor> Constructors { get; }

        IReadOnlyList<IProperty> Properties { get; }

        IReadOnlyList<IMethod> Methods { get; }

        IReadOnlyList<IGenericTypeArgument> GenericTypeArguments { get; }

        IReadOnlyList<IConstraint> ConstraintClauses { get; }

        IReadOnlyList<IIndexer> Indexers { get; }

        IReadOnlyList<IEvent> Events { get; }

        IReadOnlyList<IOperator> Operators { get; }

        IReadOnlyList<IConversionOperator> ConversionOperators { get; }
    }
}
