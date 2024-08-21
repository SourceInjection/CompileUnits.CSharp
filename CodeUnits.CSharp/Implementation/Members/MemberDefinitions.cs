using System.Collections.Generic;
using CodeUnits.CSharp.Visitors;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal static class MemberDefinitions
    {
        public static List<MemberDefinition> FromContext(Struct_bodyContext context)
        {
            var members = new List<MemberDefinition>();

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
            if (context.class_member_declarations() is null)
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
    }
}
