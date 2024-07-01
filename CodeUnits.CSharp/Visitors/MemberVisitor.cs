
using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Exceptions;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Visitors.Common;
using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors
{
    internal class MemberVisitor : CSharpParserBaseVisitor<List<MemberDefinition>>
    {
        public override List<MemberDefinition> VisitStruct_member_declaration([NotNull] Struct_member_declarationContext context)
        {
            if (context.fixed_size_buffer_declarator() != null)
                throw new NotSupportedException("fixed size buffers are not supported.");

            var commonInfo = new CommonDefinitionInfo(
                    attributeGroups: AttributeGroups.FromContext(context.attributes()),
                    modifiers:       context.all_member_modifiers().all_member_modifier().Select(c => c.GetText()));

            return CommonMembers(context.common_member_declaration(), commonInfo)
                .ToList();
        }

        public override List<MemberDefinition> VisitClass_member_declaration([NotNull] Class_member_declarationContext context)
        {
            var attributes = AttributeGroups.FromContext(context.attributes());
            if (context.destructor_definition() != null)
                return new List<MemberDefinition>() { Destructor(context.destructor_definition(), attributes) };

            var commonInfo = new CommonDefinitionInfo(
                    attributeGroups: attributes,
                    modifiers: context.all_member_modifiers().all_member_modifier().Select(c => c.GetText()));

            return CommonMembers(context.common_member_declaration(), commonInfo)
                .ToList();
        }

        private static DestructorDefinition Destructor(Destructor_definitionContext context, List<AttributeGroup> attributeGroups)
        {
            return new DestructorDefinition(attributeGroups, new Code(context.body().block()));
        }

        private static MemberDefinition[] CommonMembers(Common_member_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context is null)
                return Array.Empty<MemberDefinition>();

            if (context.constant_declaration() != null)
                return Constants(context.constant_declaration(), commonInfo).ToArray();
            if (context.typed_member_declaration() != null)
                return TypedMembers(context.typed_member_declaration(), commonInfo);
            // TODO event declaration


        }

        private static MemberDefinition[] TypedMembers(Typed_member_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            var type = new TypeUsage(context.type_());

            if (context.field_declaration() != null)
                return FieldDefinitions(context.field_declaration(), commonInfo, type).ToArray();

            var addressedInterface = context.namespace_or_type_name() == null
                ? null
                : new TypeUsage(context.namespace_or_type_name());

            var extendedInfo = new ExtendedDefinitionInfo(
                commonInfo:         commonInfo,
                hasRefModifier:     context.REF() != null,
                isReadonly:         context.READONLY() != null,
                type:               type,
                addressedInterface:    addressedInterface);

            if (context.method_declaration() != null)
                return new MethodDefinition[] { MethodDefinition(context.method_declaration(), extendedInfo, false) };
            if (context.property_declaration() != null)
                return new PropertyDefinition[] { PropertyDefinition(context.property_declaration(), extendedInfo) };
            if (context.indexer_declaration() != null)
                return new IndexerDefinition[] { IndexerDefinition(context.indexer_declaration(), extendedInfo) };
            if (context.operator_declaration() != null)
                return new OperatorDefinition[] { OperatorDefinition(context.operator_declaration(), extendedInfo) };

            var line = context.Start.Line;
            var col = context.Start.Column;
            throw new MalformedCodeException($"Syntax error at line {line} column {col}: malformed typed member definition.");
        }

        private static IEnumerable<>


        private static IEnumerable<FieldDefinition> FieldDefinitions(Field_declarationContext context, CommonDefinitionInfo commonInfo, TypeUsage type)
        {
            var fieldDefinitionInfo = new FieldDefinitionInfo(commonInfo, type);

            foreach(var fieldContext in context.variable_declarators().variable_declarator())
                yield return FieldDefinition(fieldContext, fieldDefinitionInfo);
        }

        private static FieldDefinition FieldDefinition(Variable_declaratorContext context, FieldDefinitionInfo fieldInfo)
        {
            Expression defaultValue = null;
            if(context.variable_initializer() != null)
            {
                if (context.variable_initializer().expression() != null)
                    defaultValue = new Expression(context.variable_initializer().expression());
                else if (context.variable_initializer().array_initializer() != null)
                    defaultValue = new Expression(context.variable_initializer().array_initializer());
            }

            return new FieldDefinition(
                name:            context.identifier().GetText(),
                accessModifier:  fieldInfo.Modifiers.AccessModifier,
                hasNewModifier:  fieldInfo.Modifiers.HasNewModifier,
                attributeGroups: fieldInfo.AttributeGroups,
                type:            fieldInfo.Type,
                isStatic:        fieldInfo.Modifiers.IsStatic,
                isReadonly:      fieldInfo.Modifiers.IsReadonly,
                isNew:           fieldInfo.Modifiers.HasNewModifier,
                defaultValue:    defaultValue);
        }

        private static IndexerDefinition IndexerDefinition(Indexer_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = Accessors.FromContext(context);

            return new IndexerDefinition(
                accessModifier:      modifiers.AccessModifier,
                hasNewModifier:      modifiers.HasNewModifier,
                attributeGroups:     extendedInfo.AttributeGroups,
                type:                extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                hasRefModifier:      extendedInfo.HasRefModifier,
                getter:              getter,
                setter:              setter,
                addressedInterface:  extendedInfo.AddressedInterface);
        }

        private static MethodDefinition MethodDefinition(Method_declarationContext context, ExtendedDefinitionInfo extendedInfo, bool isVoid)
        {
            var modifiers = Modifiers.OfMethod(extendedInfo.Modifiers);
            var (name, addressedInterface) = ResolvedName.FromContext(context.method_member_name());
            var typeArguments = GenericTypeArguments.FromContext(context.type_parameter_list());
            var parameters = Parameters.FromContext(context.formal_parameter_list());

            var returnType = extendedInfo.Type;
            if(isVoid)
                returnType = TypeUsage.Void;

            var body = context.method_body()?.block() == null
                ? null
                : new Code(context.method_body().block());

            return new MethodDefinition(
                name:                 name,
                accessModifier:       modifiers.AccessModifier,
                hasNewModifier:       modifiers.HasNewModifier,
                attributeGroups:      extendedInfo.AttributeGroups,
                genericTypeArguments: typeArguments,
                parameters:           parameters,
                returnType:           returnType,
                inheritanceModifier:  modifiers.InheritanceModifier,
                body:                 body,
                addressedInterface:   addressedInterface);
        }

        private static PropertyDefinition PropertyDefinition(Property_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = Accessors.FromContext(context);
            var (name, addressedInterface) = ResolvedName.FromContext(context.member_name().namespace_or_type_name());
            Expression defaultValue = null;
            if(context.variable_initializer() != null)
            {
                if (context.variable_initializer().array_initializer() != null)
                    defaultValue = new Expression(context.variable_initializer().array_initializer());
                else if (context.variable_initializer().expression() != null)
                    defaultValue = new Expression(context.variable_initializer().expression());
            }

            return new PropertyDefinition(
                name:                name,
                accessModifier:      modifiers.AccessModifier,
                hasNewModifier:      modifiers.HasNewModifier,
                attributeGroups:     extendedInfo.AttributeGroups,
                type:                extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                hasRefModifier:      extendedInfo.HasRefModifier,
                getter:              getter,
                setter:              setter,
                addressedInterface:  addressedInterface,
                defaultValue:        defaultValue);
        }

        private static OperatorDefinition OperatorDefinition(Operator_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            var name = context.overloadable_operator().GetText();
            var parameters = Parameters.FromContext(context);
            
            var body = context.body()?.block() == null
                ? null
                : new Code(context.body().block());

            return new OperatorDefinition(
                name:               name,
                attributeGroups:    extendedInfo.AttributeGroups,
                parameters:         parameters,
                returnType:         extendedInfo.Type,
                body:               body,
                addressedInterface: extendedInfo.AddressedInterface);
        }

        private static IEnumerable<ConstantDefinition> Constants(Constant_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            var declarators = ConstantDeclarators(context.constant_declarators()?.constant_declarator());
            var type = new TypeUsage(context.type_());
            (var accessModifier, var hasNewModifier) = Modifiers.OfConstant(commonInfo.Modifiers);

            foreach(var (ident, expression) in declarators)
            {
                yield return new ConstantDefinition(
                    name:            ident,
                    modifier:        accessModifier,
                    hasNewModifier:  hasNewModifier,
                    attributeGroups: commonInfo.AttributeGroups,
                    type:            type,
                    value:           expression);
            }
        }

        private static IEnumerable<(string Ident, Expression Expression)> ConstantDeclarators(Constant_declaratorContext[] contexts)
        {
            if (contexts is null)
                yield break;

            foreach(var c in contexts)
                yield return (c.identifier().GetText(), new Expression(c.expression()));
        }
    }
}
