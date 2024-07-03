using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class IndexerDefinition : MemberDefinition, IIndexer
    {
        internal IndexerDefinition(
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            InheritanceModifier inheritanceModifier,
            bool hasRefModifier,
            AccessorDefinition getter,
            AccessorDefinition setter,
            TypeUsage addressedInterface)

            : base(
                  name: "[]",
                  modifier: accessModifier,
                  attributeGroups: attributeGroups)
        {
            ReturnType = type;
            HasRefModifier = hasRefModifier;
            Getter = getter;
            Setter = setter;
            HasNewModifier = hasNewModifier;
            AddressedInterface = addressedInterface;
            InheritanceModifier = inheritanceModifier;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Indexer;

        public ITypeUsage ReturnType { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public IAccessor Getter { get; }

        public IAccessor Setter { get; }

        public bool HasNewModifier { get; }

        public ITypeUsage AddressedInterface { get; }

        internal static IndexerDefinition FromContext(Indexer_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = AccessorDefinitions.FromContext(context);

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
