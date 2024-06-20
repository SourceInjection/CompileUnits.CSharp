
using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Generated;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors
{
    internal class MemberVisitor : CSharpParserBaseVisitor<MemberDefinition>
    {

        public override MemberDefinition VisitStruct_member_declaration([NotNull] Struct_member_declarationContext context)
        {
            return base.VisitStruct_member_declaration(context);
        }

        public override MemberDefinition VisitClass_member_declaration([NotNull] Class_member_declarationContext context)
        {
            return base.VisitClass_member_declaration(context);
        }
    }
}
