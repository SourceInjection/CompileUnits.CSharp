using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    public interface IAttributeable
    {
        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }
    }

    public static class IAttributeableExtensions
    {
        /// <summary>
        /// Lists the attributes placed over a attribuetable object.<br/>
        /// </summary>
        /// <param name="member"></param>
        /// <returns>All attributes placed over a attributeable object.</returns>
        public static IEnumerable<IAttribute> Attributes(this IMember member)
        {
            return member.AttributeGroups.SelectMany(m => m.Attributes);
        }
    }
}
