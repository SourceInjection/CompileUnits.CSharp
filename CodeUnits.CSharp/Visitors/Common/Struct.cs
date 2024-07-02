using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Struct
    {
        public static StructDefinition FromContext(Struct_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfStruct(commonInfo.Modifiers);
            var isRecord = context.RECORD() != null;
            var genericTypeArguments = GenericTypeArguments.FromContext(context.type_parameter_list());

            return new StructDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: Members.FromContext(context.struct_body()),
                genericTypeArguments: genericTypeArguments,
                constraints: Constraints.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments),
                isRecord: isRecord,
                isReadonly: modifiers.IsReadonly);
        }
    }
}
