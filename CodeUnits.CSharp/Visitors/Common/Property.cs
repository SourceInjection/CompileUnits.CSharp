
using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Property
    {
        public static PropertyDefinition FromContext(Property_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = Accessors.FromContext(context);
            var (name, addressedInterface) = ResolvedName.FromContext(context.member_name().namespace_or_type_name());
            Expression defaultValue = null;
            if (context.variable_initializer() != null)
            {
                if (context.variable_initializer().array_initializer() != null)
                    defaultValue = new Expression(context.variable_initializer().array_initializer());
                else if (context.variable_initializer().expression() != null)
                    defaultValue = new Expression(context.variable_initializer().expression());
            }

            return new PropertyDefinition(
                name: name,
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: extendedInfo.AttributeGroups,
                type: extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                hasRefModifier: extendedInfo.HasRefModifier,
                getter: getter,
                setter: setter,
                addressedInterface: addressedInterface,
                defaultValue: defaultValue);
        }
    }
}
