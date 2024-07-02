using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Enum
    {
        public static EnumDefinition FromContext(Enum_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfEnum(commonInfo.Modifiers);
            var baseType = context.enum_base()?.type_() is null
                ? null
                : new TypeUsage(context.enum_base().type_());

            return new EnumDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: Members.FromContext(context.enum_body()),
                baseType: baseType);
        }
    }
}
