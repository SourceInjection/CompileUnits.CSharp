using Antlr4.Runtime.Misc;
using CompileUnits.CSharp.Generated;
using CompileUnits.CSharp.Implementation;
using CompileUnits.CSharp.Implementation.Usings;

namespace CompileUnits.CSharp.Visitors
{
    internal class UsingVisitor : CSharpParserBaseVisitor<UsingDirectiveDefinition>
    {
        public override UsingDirectiveDefinition VisitUsing_alias_directive([NotNull] CSharpParser.Using_alias_directiveContext context)
        {
            return new UsingAliasDirectiveDefinition(context.identifier().GetText(), TypeUsage.FromContext(context.namespace_or_type_name()));
        }

        public override UsingDirectiveDefinition VisitUsing_namespace_directive([NotNull] CSharpParser.Using_namespace_directiveContext context)
        {
            return new UsingNamespaceDirectiveDefinition(context.namespace_or_type_name().GetText());
        }

        public override UsingDirectiveDefinition VisitUsing_static_directive([NotNull] CSharpParser.Using_static_directiveContext context)
        {
            return new UsingStaticDirectiveDefinition(TypeUsage.FromContext(context.namespace_or_type_name()));
        }
    }
}
