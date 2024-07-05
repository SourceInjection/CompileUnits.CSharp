using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Implementation;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members;
using CodeUnits.CSharp.Implementation.Members.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors
{
    internal class MemberVisitor : CSharpParserBaseVisitor<MemberDefinition[]>
    {
        public override MemberDefinition[] VisitStruct_member_declaration([NotNull] Struct_member_declarationContext context)
        {
            if (context.fixed_size_buffer_declarator() != null)
                throw new NotSupportedException("fixed size buffers are not supported.");

            var commonInfo = new CommonDefinitionInfo(
                    attributeGroups: AttributeGroups.FromContext(context.attributes()),
                    modifiers: GetModifiers(context.all_member_modifiers()));

            return GetCommonMembers(context.common_member_declaration(), commonInfo);
        }

        public override MemberDefinition[] VisitClass_member_declaration([NotNull] Class_member_declarationContext context)
        {
            var attributes = AttributeGroups.FromContext(context.attributes());
            if (context.destructor_definition() != null)
                return new MemberDefinition[] { FinalizerDefinition.FromContext(context.destructor_definition(), attributes) };

            var commonInfo = new CommonDefinitionInfo(
                    attributeGroups: attributes,
                    modifiers: GetModifiers(context.all_member_modifiers()));

            return GetCommonMembers(context.common_member_declaration(), commonInfo);
        }

        private static MemberDefinition[] GetCommonMembers(Common_member_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context is null)
                return Array.Empty<MemberDefinition>();

            if (context.constant_declaration() != null)
                return ConstantDefinitions.FromContext(context.constant_declaration(), commonInfo).ToArray();
            if (context.typed_member_declaration() != null)
                return GetTypedMembers(context.typed_member_declaration(), commonInfo);
            if (context.event_declaration() != null)
                return EventDefinitions.FromContext(context.event_declaration(), commonInfo).ToArray();
            if (context.conversion_operator_declarator() != null)
                return new ConversionOperatorDefinition[] { ConversionOperatorDefinition.FromContext(context.conversion_operator_declarator(), commonInfo) };
            if (context.constructor_declaration() != null)
                return new ConstructorDefinition[] { ConstructorDefinition.FromContext(context.constructor_declaration(), commonInfo) };
            if (context.method_declaration() != null)
                return new MethodDefinition[] { MethodDefinition.FromContext(context.method_declaration(), new ExtendedDefinitionInfo(commonInfo)) };
            if (context.class_definition() != null)
                return new ClassDefinition[] { ClassDefinition.FromContext(context.class_definition(), commonInfo) };
            if (context.struct_definition() != null)
                return new StructDefinition[] { StructDefinition.FromContext(context.struct_definition(), commonInfo) };
            if (context.interface_definition() != null)
                return new InterfaceDefinition[] { InterfaceDefinition.FromContext(context.interface_definition(), commonInfo) };
            if (context.enum_definition() != null)
                return new EnumDefinition[] { EnumDefinition.FromContext(context.enum_definition(), commonInfo) };

            return new DelegateDefinition[] { DelegateDefinition.FromContext(context.delegate_definition(), commonInfo) };
        }

        private static MemberDefinition[] GetTypedMembers(Typed_member_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            var type = TypeUsage.FromContext(context.type_());

            if (context.field_declaration() != null)
                return FieldDefinitions(context.field_declaration(), commonInfo, type).ToArray();

            var extendedInfo = new ExtendedDefinitionInfo(
                commonInfo:         commonInfo,
                hasRefModifier:     context.REF() != null,
                isReadonly:         context.READONLY() != null,
                type:               type,
                addressedInterface: TypeUsage.FromContext(context.namespace_or_type_name()));

            if (context.method_declaration() != null)
                return new MethodDefinition[] { MethodDefinition.FromContext(context.method_declaration(), extendedInfo) };
            if (context.property_declaration() != null)
                return new PropertyDefinition[] { PropertyDefinition.FromContext(context.property_declaration(), extendedInfo) };
            if (context.indexer_declaration() != null)
                return new IndexerDefinition[] { IndexerDefinition.FromContext(context.indexer_declaration(), extendedInfo) };

            return new OperatorDefinition[] { OperatorDefinition.FromContext(context.operator_declaration(), extendedInfo) };
        }

        private static IEnumerable<FieldDefinition> FieldDefinitions(Field_declarationContext context, CommonDefinitionInfo commonInfo, TypeUsage type)
        {
            var fieldDefinitionInfo = new FieldDefinitionInfo(commonInfo, type);

            foreach(var fieldContext in context.variable_declarators().variable_declarator())
                yield return FieldDefinition.FromContext(fieldContext, fieldDefinitionInfo);
        }

        private static IEnumerable<string> GetModifiers(All_member_modifiersContext context)
        {
            if (context?.all_member_modifier() == null)
                return Enumerable.Empty<string>();
            return context.all_member_modifier().Select(c => c.GetText());
        }
    }
}
