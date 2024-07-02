using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Visitors;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    internal static class TypeDefinitions
    {
        public static List<TypeDefinition> FromContext(Namespace_member_declarationsContext context)
        {
            if (context == null)
                return new List<TypeDefinition>();

            var types = new List<TypeDefinition>();
            var visitor = new TypeVisitor();

            var typeContexts = context.namespace_member_declaration()
                .Where(c => c.type_declaration() != null)
                .Select(c => c.type_declaration());

            foreach (var c in typeContexts)
            {
                var type = visitor.VisitType_declaration(c);
                if (type != null)
                    types.Add(type);
            }
            return types;
        }
    }
}
