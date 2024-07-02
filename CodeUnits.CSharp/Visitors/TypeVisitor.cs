using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Exceptions;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Visitors.Common;
using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;
using Enum = CodeUnits.CSharp.Visitors.Common.Enum;
using Delegate = CodeUnits.CSharp.Visitors.Common.Delegate;

namespace CodeUnits.CSharp.Visitors
{
    internal class TypeVisitor : CSharpParserBaseVisitor<TypeDefinition>
    {
        public override TypeDefinition VisitType_declaration([NotNull] Type_declarationContext context)
        {
            var commonInfo = new CommonDefinitionInfo(
                GetAllMemberModifiers(context),
                AttributeGroups.FromContext(context.attributes()));

            if(context.interface_definition() != null)
                return Interface.FromContext(context.interface_definition(), commonInfo);
            if (context.class_definition() != null)
                return Class.FromContext(context.class_definition(), commonInfo);
            if(context.struct_definition() != null)
                return Struct.FromContext(context.struct_definition(), commonInfo);
            if (context.enum_definition() != null)
                return Enum.FromContext(context.enum_definition(), commonInfo);
            if (context.delegate_definition() != null)
                return Delegate.FromContext(context.delegate_definition(), commonInfo);

            var line = context.Start.Line;
            var col = context.Start.Column;
            throw new MalformedCodeException($"Syntax error at line {line} column {col}: malformed type definition.");
        }

        private static string[] GetAllMemberModifiers(Type_declarationContext context)
        {
            if (context?.all_member_modifiers()?.all_member_modifier() is null)
                return Array.Empty<string>();

            return context.all_member_modifiers().all_member_modifier()
                .Select(c => c.GetText())
                .ToArray();            
        }
    }
}
