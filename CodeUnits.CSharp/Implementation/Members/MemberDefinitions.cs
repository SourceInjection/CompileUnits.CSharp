using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Members.Minor;
using CodeUnits.CSharp.Visitors;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal static class MemberDefinitions
    {
        public static List<MemberDefinition> FromContext(Struct_bodyContext context)
        {
            var members = new List<MemberDefinition>();
            if (context?.struct_member_declaration() is null)
                return members;

            var visitor = new MemberVisitor();
            foreach (var c in context.struct_member_declaration())
            {
                var definitions = visitor.VisitStruct_member_declaration(c);
                if (definitions.Length > 0)
                    members.AddRange(definitions);
            }
            return members;
        }

        public static List<MemberDefinition> FromContext(Class_bodyContext context)
        {
            var members = new List<MemberDefinition>();
            if (context?.class_member_declarations() is null)
                return members;

            var visitor = new MemberVisitor();
            foreach (var c in context.class_member_declarations().class_member_declaration())
            {
                var definitions = visitor.VisitClass_member_declaration(c);
                if (definitions.Length > 0)
                    members.AddRange(definitions);
            }
            return members;
        }

        public static List<EnumMemberDefinition> FromContext(Enum_bodyContext context)
        {
            if (context?.enum_member_declaration() is null)
                return new List<EnumMemberDefinition>();

            return context.enum_member_declaration()
                .Select(c => new EnumMemberDefinition(
                    c.identifier().GetText(),
                    CodeFragment.FromContext(c.expression()),
                    AttributeGroups.FromContext(c.attributes())))
                .ToList();
        }
    }
}
