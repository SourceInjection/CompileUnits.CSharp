using static CompileUnits.CSharp.Generated.CSharpParser;
using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Common;

namespace CompileUnits.CSharp.Implementation.Members
{
    internal static class ConstantDefinitions
    {
        public static IEnumerable<ConstantDefinition> FromContext(Constant_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            var declarators = ConstantDeclarators(context.constant_declarators().constant_declarator());
            var type = TypeUsage.FromContext(context.type_());
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
            foreach (var c in contexts)
                yield return (c.identifier().GetText(), Expression.FromContext(c.expression()));
        }
    }
}
