using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Operator
    {
        public static OperatorDefinition FromContext(Operator_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var name = context.overloadable_operator().GetText();
            var parameters = Parameters.FromContext(context);

            var body = context.body()?.block() == null
                ? null
                : new Code(context.body().block());

            return new OperatorDefinition(
                name: name,
                attributeGroups: extendedInfo.AttributeGroups,
                parameters: parameters,
                returnType: extendedInfo.Type,
                body: body,
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
