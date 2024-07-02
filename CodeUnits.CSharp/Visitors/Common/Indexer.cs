using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal class Indexer
    {
        public static IndexerDefinition FromContext(Indexer_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = Accessors.FromContext(context);

            return new IndexerDefinition(
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: extendedInfo.AttributeGroups,
                type: extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                hasRefModifier: extendedInfo.HasRefModifier,
                getter: getter,
                setter: setter,
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
