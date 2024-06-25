using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Parameters
    {
        public static List<ParameterDefinition> FromContext(Formal_parameter_listContext context)
        {
            var parameters = new List<ParameterDefinition>();
            if (context.fixed_parameters() != null)
                parameters.AddRange(FromFixedParameters(context.fixed_parameters()));

            if (context.parameter_array() != null)
                parameters.Add(FromParameterArrayContext(context.parameter_array()));

            return parameters;
        }

        private static ParameterDefinition FromParameterArrayContext(Parameter_arrayContext context)
        {
            return new ParameterDefinition(
                type:          new TypeUsage(context.array_type()), 
                name:          context.identifier().GetText(), 
                modifier:      ParameterModifier.None,
                attributes:    AttributeGroups.FromContext(context.attributes()),
                isParamsArray: true,
                defaultValue:  null);
        }

        private static IEnumerable<ParameterDefinition> FromFixedParameters(Fixed_parametersContext context)
        {
            if(context.fixed_parameter() != null)
            {
                foreach(var c in context.fixed_parameter())
                {
                    var expression = c.arg_declaration().expression() is null
                        ? null
                        : new Expression(c.arg_declaration().expression());

                    yield return new ParameterDefinition(
                        type:          new TypeUsage(c.arg_declaration().type_()),
                        name:          c.arg_declaration().identifier().GetText(),
                        modifier:      FromModifierContext(c.parameter_modifier()),
                        attributes:    AttributeGroups.FromContext(c.attributes()),
                        isParamsArray: false,
                        defaultValue:  expression);
                }
            }
        }

        private static ParameterModifier FromModifierContext(Parameter_modifierContext context)
        {
            if (context is null)
                return ParameterModifier.None;
            if(context.THIS() != null)
            {
                if (context.REF() != null)
                    return ParameterModifier.RefThis;
                if(context.IN() != null)
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
