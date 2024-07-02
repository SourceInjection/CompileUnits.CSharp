using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Class
    {
        public static ClassDefinition FromContext(Class_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfClass(commonInfo.Modifiers);
            var isRecord = context.RECORD() != null;
            var genericTypeArguments = GenericTypeArguments.FromContext(context.type_parameter_list());

            return new ClassDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: Members.FromContext(context.class_body()),
                genericTypeArguments: genericTypeArguments,
                constraints: Constraints.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments),
                isRecord: isRecord,
                isStatic: modifiers.IsStatic,
                isSealed: modifiers.IsSealed,
                isAbstract: modifiers.IsAbstract);
        }
    }
}
