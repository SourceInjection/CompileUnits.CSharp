using CodeUnits.CSharp.Visitors.ValueTypes;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Events
    {
        public static IEnumerable<EventDefinition> FromContext(Event_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                yield break;

            var type = new TypeUsage(context.type_());

            if(context.member_name() != null)
            {
                var modifiers = Modifiers.OfEvent(commonInfo.Modifiers);
                var (add, remove) = Accessors.FromContext(context.event_accessor_declarations());

                yield return new EventDefinition(
                    name: context.member_name().GetText(),
                    attributeGroups: commonInfo.AttributeGroups,
                    modifier: modifiers.AccessModifier,
                    hasNewModifier: modifiers.HasNewModifier,
                    hasStaticModifier: modifiers.IsStatic,
                    inheritanceModifier: modifiers.InheritanceModifier,
                    addAccessor: add,
                    removeAccessor: remove);
            }
            else
            {
                var info = new EventDefinitionInfo(commonInfo, type);
                foreach (var c in context.variable_declarators().variable_declarator())
                    yield return FromDeclaratorContext(c, info);
            }
        }

        private static EventDefinition FromDeclaratorContext(Variable_declaratorContext context, EventDefinitionInfo eventInfo)
        {
            var modifiers = Modifiers.OfEvent(eventInfo.Modifiers);
            return new EventDefinition(
                name: context.identifier().GetText(),
                attributeGroups: eventInfo.AttributeGroups,
                modifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                hasStaticModifier: modifiers.IsStatic,
                inheritanceModifier: modifiers.InheritanceModifier);
        }
    }
}
