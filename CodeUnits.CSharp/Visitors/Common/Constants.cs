using CodeUnits.CSharp.Visitors.ValueTypes;
using static CodeUnits.CSharp.Generated.CSharpParser;
using System.Collections.Generic;
using System;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Constants
    {
        public static IEnumerable<ConstantDefinition> FromContext(Constant_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                yield break;

            var declarators = ConstantDeclarators(context.constant_declarators()?.constant_declarator());
            var type = new TypeUsage(context.type_());
            (var accessModifier, var hasNewModifier) = Modifiers.OfConstant(commonInfo.Modifiers);

            foreach (var (ident, expression) in declarators)
            {
                yield return new ConstantDefinition(
                    name: ident,
                    modifier: accessModifier,
                    hasNewModifier: hasNewModifier,
                    attributeGroups: commonInfo.AttributeGroups,
                    type: type,
                    value: expression);
            }
        }

        private static IEnumerable<(string Ident, Expression Expression)> ConstantDeclarators(Constant_declaratorContext[] contexts)
        {
            if (contexts is null)
                yield break;

            foreach (var c in contexts)
                yield return (c.identifier().GetText(), new Expression(c.expression()));
        }
    }
}
