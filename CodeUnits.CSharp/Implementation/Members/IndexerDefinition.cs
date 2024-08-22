using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Parameters;
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
            bool isStatic,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<ParameterDefinition> parameters,
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
            Parameters = parameters;
            IsStatic = isStatic;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Indexer;

        public ITypeUsage ReturnType { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public IAccessor Getter { get; }

        public IAccessor Setter { get; }

        public bool HasNewModifier { get; }

        public bool IsStatic { get; }

        public ITypeUsage AddressedInterface { get; }

        public IReadOnlyList<IParameter> Parameters { get; }

        internal static IndexerDefinition FromContext(Indexer_declarationContext context, TypedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = AccessorDefinitions.FromContext(context);

            return new IndexerDefinition(
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                isStatic: modifiers.IsStatic,
                attributeGroups: extendedInfo.AttributeGroups,
                parameters: ParameterDefinitions.FromContext(context.formal_parameter_list()),
                type: extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                hasRefModifier: extendedInfo.HasRefModifier,
                getter: getter,
                setter: setter,
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
