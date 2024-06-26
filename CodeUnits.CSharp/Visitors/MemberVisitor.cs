
using Antlr4.Runtime.Misc;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Visitors.Common;
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

            var attributes = AttributeGroups.FromContext(context.attributes());
            var modifiers = context.all_member_modifiers().all_member_modifier().Select(c => c.GetText());

            return CommonMembers(context.common_member_declaration(), modifiers, attributes)
                .ToList();
        }

        public override List<MemberDefinition> VisitClass_member_declaration([NotNull] Class_member_declarationContext context)
        {
            var attributes = AttributeGroups.FromContext(context.attributes());
            if (context.destructor_definition() != null)
                return new List<MemberDefinition>() { Destructor(context.destructor_definition(), attributes) };

            var modifiers = context.all_member_modifiers().all_member_modifier().Select(c => c.GetText());

            return CommonMembers(context.common_member_declaration(), modifiers, attributes)
                .ToList();
        }

        private static DestructorDefinition Destructor(Destructor_definitionContext context, List<AttributeGroup> attributeGroups)
        {
            return new DestructorDefinition(attributeGroups, new Code(context.body()));
        }

        private static IEnumerable<MemberDefinition> CommonMembers(Common_member_declarationContext context, IEnumerable<string> modifiers, List<AttributeGroup> attributeGroups)
        {
            if (context is null)
                return Enumerable.Empty<MemberDefinition>();

            if (context.constant_declaration() != null)
                return Constants(context.constant_declaration(), modifiers, attributeGroups);
            if (context.typed_member_declaration() != null)
                return TypedMembers(context.typed_member_declaration(), modifiers, attributeGroups);

        }

        private static IEnumerable<MemberDefinition> TypedMembers(Typed_member_declarationContext context, IEnumerable<string> modifiers, List<AttributeGroup> attributeGroups)
        {

        }

        private static MethodDefinition 

        private static IEnumerable<ConstantDefinition> Constants(Constant_declarationContext context, IEnumerable<string> modifiers, List<AttributeGroup> attributeGroups)
        {
            var declarators = ConstantDeclarators(context.constant_declarators()?.constant_declarator());
            var type = new TypeUsage(context.type_());
            (var accessModifier, var hasNewModifier) = Modifiers.OfConstant(modifiers);

            foreach(var (ident, expression) in declarators)
            {
                yield return new ConstantDefinition(
                    name:            ident,
                    modifier:        accessModifier,
                    hasNewModifier:  hasNewModifier,
                    attributeGroups: attributeGroups,
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
