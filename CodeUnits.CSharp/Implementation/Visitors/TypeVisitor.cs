using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Generated;
using System;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Members.Types;

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
                return InterfaceDefinition.FromContext(context.interface_definition(), commonInfo);
            if (context.class_definition() != null)
                return ClassDefinition.FromContext(context.class_definition(), commonInfo);
            if(context.struct_definition() != null)
                return StructDefinition.FromContext(context.struct_definition(), commonInfo);
            if (context.enum_definition() != null)
                return EnumDefinition.FromContext(context.enum_definition(), commonInfo);

            return DelegateDefinition.FromContext(context.delegate_definition(), commonInfo);
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
