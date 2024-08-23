using System.Collections.Generic;
using System.Linq;

namespace CompileUnits.CSharp
{
    public interface IInstanceable : IStructuredType { }

    public static class IInstanceableExtensions
    {
        /// <summary>
        /// Lists the conversion operators within an instanceable type.
        /// </summary>
        /// <param name="instanceable"></param>
        /// <returns>All conversiion operators within an instanceable type.</returns>
        public static IEnumerable<IConversionOperator> ConversionOperators(this IInstanceable instanceable)
        {
            return instanceable.Members.OfType<IConversionOperator>();
        }

        /// <summary>
        /// Lists the fields within an instanceable type.
        /// </summary>
        /// <param name="instanceable"></param>
        /// <returns>All fields within an instanceable type.</returns>
        public static IEnumerable<IField> Fields(this IInstanceable instanceable)
        {
            return instanceable.Members.OfType<IField>();
        }

        /// <summary>
        /// Lists the constructors within an instanceable type.
        /// </summary>
        /// <param name="instanceable"></param>
        /// <returns>All constructors within an instanceable type.</returns>
        public static IEnumerable<IConstructor> Constructors(this IInstanceable instanceable)
        {
            return instanceable.Members.OfType<IConstructor>();
        }
    }
}
