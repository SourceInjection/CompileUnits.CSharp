using Antlr4.Runtime.Tree;
using CodeUnits.CSharp.Implementation.Attributes;
using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Parameters
{
    internal static class ParameterDefinitions
    {
        public static List<ParameterDefinition> FromContext(Formal_parameter_listContext context)
        {
            if (context == null)
                return new List<ParameterDefinition>();

            var parameters = new List<ParameterDefinition>();
            if (context.fixed_parameters() != null)
                parameters.AddRange(FromFixedParameters(context.fixed_parameters()));

            if (context.parameter_array() != null)
                parameters.Add(FromParameterArrayContext(context.parameter_array()));

            return parameters;
        }

        public static List<ParameterDefinition> FromContext(Operator_declarationContext context)
        {
            if (context == null)
                return new List<ParameterDefinition>();

            var result = new List<ParameterDefinition>();

            int i = 0;
            while (i < context.ChildCount && !(context.GetChild(i) is ITerminalNode tn && tn.Symbol.Type == OPEN_PARENS))
                i++;

            var hasInModifier = false;
            while (i < context.ChildCount)
            {
                var child = context.GetChild(i);
                if (child is ITerminalNode tn)
                {
                    if (tn.Symbol.Type == CLOSE_PARENS)
                        break;
                    if (tn.Symbol.Type == IN)
                        hasInModifier = true;
                }
                else if (child is Arg_declarationContext argDeclaration)
                {
                    result.Add(FromArgDeclarationContext(argDeclaration, hasInModifier));
                    hasInModifier = false;
                }
                i++;
            }
            return result;
        }

        private static ParameterDefinition FromArgDeclarationContext(Arg_declarationContext context, bool hasInModifier)
        {
            return new ParameterDefinition(
                type: TypeUsage.FromContext(context.type_()),
                name: context.identifier().GetText(),
                modifier: hasInModifier ? ParameterModifier.In : ParameterModifier.None,
                attributes: Array.Empty<AttributeGroup>(),
                isParamsArray: false,
                defaultValue: null);
        }

        private static ParameterDefinition FromParameterArrayContext(Parameter_arrayContext context)
        {
            return new ParameterDefinition(
                type: TypeUsage.FromContext(context.array_type()),
                name: context.identifier().GetText(),
                modifier: ParameterModifier.None,
                attributes: AttributeGroups.FromContext(context.attributes()),
                isParamsArray: true,
                defaultValue: null);
        }

        private static IEnumerable<ParameterDefinition> FromFixedParameters(Fixed_parametersContext context)
        {
            if (context.fixed_parameter() != null)
            {
                foreach (var c in context.fixed_parameter())
                {
                    var expression = CodeFragment.FromContext(c.arg_declaration().expression());
                    yield return new ParameterDefinition(
                        type: TypeUsage.FromContext(c.arg_declaration().type_()),
                        name: c.arg_declaration().identifier().GetText(),
                        modifier: FromModifierContext(c.parameter_modifier()),
                        attributes: AttributeGroups.FromContext(c.attributes()),
                        isParamsArray: false,
                        defaultValue: expression);
                }
            }
        }

        private static ParameterModifier FromModifierContext(Parameter_modifierContext context)
        {
            if (context is null)
                return ParameterModifier.None;
            if (context.THIS() != null)
            {
                if (context.REF() != null)
                    return ParameterModifier.RefThis;
                if (context.IN() != null)
                    return ParameterModifier.InThis;
                return ParameterModifier.This;
            }
            if (context.IN() != null)
                return ParameterModifier.In;
            if (context.OUT() != null)
                return ParameterModifier.Out;
            return ParameterModifier.None;
        }
    }
}
