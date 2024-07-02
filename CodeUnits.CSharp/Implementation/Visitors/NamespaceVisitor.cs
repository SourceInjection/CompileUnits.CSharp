using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Implementation;
using CodeUnits.CSharp.Implementation.Members.Types;
using CodeUnits.CSharp.Implementation.Usings;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors
{
    internal class NamespaceVisitor : CSharpParserBaseVisitor<NamespaceDefinition>
    {
        public override NamespaceDefinition VisitCompilation_unit([NotNull] Compilation_unitContext context)
        {
            return new NamespaceDefinition(
                name:          string.Empty,
                directives:    UsingDirectives.FromContext(context.using_directives()),
                namespaces:    GetNamespacesFromContext(context.namespace_member_declarations()),
                types:         TypeDefinitions.FromContext(context.namespace_member_declarations()),
                externAliases: ExternAliasDefinitions.FromContext(context.extern_alias_directives()));
        }

        public override NamespaceDefinition VisitNamespace_declaration([NotNull] Namespace_declarationContext context)
        {
            var name = context.qualified_identifier().GetText();
            return GetNamespaceFromBody(name, context.namespace_body());
        }

        private NamespaceDefinition GetNamespaceFromBody(string name, Namespace_bodyContext context)
        {
            return new NamespaceDefinition(
                name:          name,
                directives:    UsingDirectives.FromContext(context.using_directives()),
                namespaces:    GetNamespacesFromContext(context.namespace_member_declarations()),
                types:         TypeDefinitions.FromContext(context.namespace_member_declarations()),
                externAliases: ExternAliasDefinitions.FromContext(context.extern_alias_directives()));
        }

        private List<NamespaceDefinition> GetNamespacesFromContext(Namespace_member_declarationsContext context)
        {
            var namespaces = new List<NamespaceDefinition>();

            var nsContexts = context.namespace_member_declaration()
                .Where(c => c.namespace_declaration() != null)
                .Select(c => c.namespace_declaration());

            foreach (var c in nsContexts)
            {
                var ns = VisitNamespace_declaration(c);
                if(ns != null)
                    namespaces.Add(ns);
            }
            return namespaces;
        }
    }
}
