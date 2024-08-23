using System.Collections.Generic;
using System.Linq;

namespace CompileUnits.CSharp
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
        /// Lists the generic type argumetns within a structured type.
        /// </summary>
        IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        /// <summary>
        /// Lists the constraints within a structured type.
        /// </summary>
        IReadOnlyList<IConstraint> Constraints { get; }

        /// <summary>
        /// Lists the implemented interfaces within a structured type.
        /// </summary>
        IReadOnlyList<ITypeUsage> Inheritance { get; }
    }

    public static class IStructuredTypeExtensions
    {
        /// <summary>
        /// Lists the operators within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All operators within a structured type.</returns>
        public static IEnumerable<IOperator> Operators(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IOperator>();
        }

        /// <summary>
        /// Lists the events within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All events within a structured type.</returns>
        public static IEnumerable<IEvent> Events(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IEvent>();
        }

        /// <summary>
        /// Lists the indexers within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All indexers within a structured type.</returns>
        public static IEnumerable<IIndexer> Indexers(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IIndexer>();
        }

        /// <summary>
        /// Lists the types within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All type definitinos within a structured type.</returns>
        public static IEnumerable<IType> Types(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IType>();
        }

        /// <summary>
        /// Lists the constants within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All constants within a structured type.</returns>
        public static IEnumerable<IConstant> Constants(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IConstant>();
        }

        /// <summary>
        /// Lists the properties within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All properties within a structured type.</returns>
        public static IEnumerable<IProperty> Properties(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IProperty>();
        }

        /// <summary>
        /// Lists the methods within a structured type.
        /// </summary>
        /// <param name="structuredType"></param>
        /// <returns>All methods within a structured type.</returns>
        public static IEnumerable<IMethod> Methods(this IStructuredType structuredType)
        {
            return structuredType.Members.OfType<IMethod>();
        }
    }
}
