using Antlr4.Runtime.Misc;
using CompileUnits.CSharp.Generated;
using CompileUnits.CSharp.Implementation;
using CompileUnits.CSharp.Implementation.Usings;
using System.Collections.Generic;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Visitors
{
    internal class NamespaceVisitor : CSharpParserBaseVisitor<NamespaceDefinition>
    {
        public override NamespaceDefinition VisitCompilation_unit([NotNull] Compilation_unitContext context)
        {
            return new NamespaceDefinition(
                name:          string.Empty,
                directives:    UsingDirectives.FromContext(context.using_directives()),
                members:       GetNamespaceMembers(context.namespace_member_declarations()),
                externAliases: ExternAliasDefinitions.FromContext(context.extern_alias_directives()));
        }

        public override NamespaceDefinition VisitNamespace_declaration([NotNull] Namespace_declarationContext context)
        {
            var name = context.qualified_identifier().GetText();
            return GetNamespaceFromBody(name, context.namespace_body());
        }

        private List<INamespaceMember> GetNamespaceMembers(Namespace_member_declarationsContext context)
        {
            var result = new List<INamespaceMember>();
            if (context?.namespace_member_declaration() == null)
                return result;

            var typeVisitor = new TypeVisitor();

            foreach(var c in context.namespace_member_declaration())
            {
                if (c.namespace_declaration() != null)
                    result.Add(VisitNamespace_declaration(c.namespace_declaration()));
                else if(c.type_declaration() != null)
                    result.Add(typeVisitor.VisitType_declaration(c.type_declaration()));
            }
            return result;
        }

        private NamespaceDefinition GetNamespaceFromBody(string name, Namespace_bodyContext context)
        {
            return new NamespaceDefinition(
                name:          name,
                directives:    UsingDirectives.FromContext(context.using_directives()),
                members:       GetNamespaceMembers(context.namespace_member_declarations()),
                externAliases: ExternAliasDefinitions.FromContext(context.extern_alias_directives()));
        }
    }
}
