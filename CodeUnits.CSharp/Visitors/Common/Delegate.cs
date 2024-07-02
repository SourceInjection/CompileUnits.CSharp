using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Delegate
    {
        public static DelegateDefinition FromContext(Delegate_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfDelegate(commonInfo.Modifiers);
            var genericTypeArguments = GenericTypeArguments.FromContext(context.variant_type_parameter_list());
            var returnType = context.return_type().type_() is null
                ? TypeUsage.Void
                : new TypeUsage(context.return_type().type_());

            return new DelegateDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                returnType: returnType,
                parameters: Parameters.FromContext(context.formal_parameter_list()),
                genericTypeArguments: genericTypeArguments,
                constraints: Constraints.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments));
        }
    }
}
