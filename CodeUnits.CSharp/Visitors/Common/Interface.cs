using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Interface
    {
        public static InterfaceDefinition FromContext(Interface_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfInterface(commonInfo.Modifiers);
            var genericTypeArguments = GenericTypeArguments.FromContext(context.variant_type_parameter_list());

            return new InterfaceDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: Members.FromContext(context.class_body()),
                genericTypeArguments: genericTypeArguments,
                constraints: Constraints.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments));
        }
    }
}
