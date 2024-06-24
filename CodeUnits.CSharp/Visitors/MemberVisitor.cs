
using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Generated;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors
{
    internal class MemberVisitor : CSharpParserBaseVisitor<MemberDefinition>
    {

        public override MemberDefinition VisitStruct_member_declaration([NotNull] Struct_member_declarationContext context)
        {
            int x = 3;
            x >>= 1;
        }

        public override MemberDefinition VisitClass_member_declaration([NotNull] Class_member_declarationContext context)
        {

        }
    }
}
