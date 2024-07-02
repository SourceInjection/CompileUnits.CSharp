using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Implementation.Parameters;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Attributes
{
    internal static class AttributeGroups
    {
        public static List<AttributeGroup> FromContext(AttributesContext context)
        {
            var sections = new List<AttributeGroup>();
            if (context?.attribute_section() is null)
                return sections;

            foreach (var sectionContext in context.attribute_section())
            {
                var attributeTarget = sectionContext.attribute_target()?.GetText();
                var attributes = new List<AttributeUsage>();

                var attributeContexts = sectionContext.attribute_list()?.attribute();
                if (attributeContexts != null)
                {
                    foreach (var attributeContext in attributeContexts)
                    {
                        var name = attributeContext.namespace_or_type_name().GetText();
                        var args = Arguments.FromContext(attributeContext.attribute_argument()).ToArray();
                        attributes.Add(new AttributeUsage(name, args));
                    }
                }
                sections.Add(new AttributeGroup(attributeTarget, attributes));
            }
            return sections;
        }
    }
}
