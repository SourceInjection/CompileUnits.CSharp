using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Method
    {
        public static MethodDefinition FromContext(Method_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfMethod(extendedInfo.Modifiers);
            var (name, addressedInterface) = ResolvedName.FromContext(context.method_member_name());
            var typeArguments = GenericTypeArguments.FromContext(context.type_parameter_list());
            var parameters = Parameters.FromContext(context.formal_parameter_list());

            var returnType = extendedInfo.Type;

            var body = context.method_body()?.block() == null
                ? null
                : new Code(context.method_body().block());

            return new MethodDefinition(
                name: name,
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: extendedInfo.AttributeGroups,
                genericTypeArguments: typeArguments,
                parameters: parameters,
                returnType: returnType,
                inheritanceModifier: modifiers.InheritanceModifier,
                body: body,
                addressedInterface: addressedInterface);
        }
    }
}
