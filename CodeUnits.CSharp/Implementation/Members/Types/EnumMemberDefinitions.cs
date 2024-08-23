using CodeUnits.CSharp.Implementation.Members.Minor;
using System.Linq;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    internal class EnumMemberDefinitions
    {
        public static List<EnumMemberDefinition> FromContext(Enum_bodyContext context)
        {
            return context.enum_member_declaration()
                .Select(c => new EnumMemberDefinition(
                    c.identifier().GetText(),
                    Expression.FromContext(c.expression()),
                    AttributeGroups.FromContext(c.attributes())))
                .ToList();
        }
    }
}
