using CompileUnits.CSharp.Implementation.Attributes;
using CompileUnits.CSharp.Implementation.Common;
using System.Collections.Generic;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation.Members
{
    internal class PropertyDefinition : MemberDefinition, IProperty
    {
        internal PropertyDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            InheritanceModifier inheritanceModifier,
            bool hasRefModifier,
            bool isStatic,
            AccessorDefinition getter,
            AccessorDefinition setter,
            TypeUsage addressedInterface,
            Expression defaultValue)

            : base(
                  name: name,
                  modifier: accessModifier,
                  attributeGroups: attributeGroups)
        {
            Type = type;
            HasRefModifier = hasRefModifier;
            Getter = getter;
            Setter = setter;
            HasNewModifier = hasNewModifier;
            AddressedInterface = addressedInterface;
            InheritanceModifier = inheritanceModifier;
            Initialization = defaultValue;
            IsStatic = isStatic;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Property;

        public ITypeUsage Type { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public IAccessor Getter { get; }

        public IAccessor Setter { get; }

        public bool HasNewModifier { get; }

        public bool IsStatic { get; }

        public ITypeUsage AddressedInterface { get; }

        public IExpression Initialization { get; }

        internal static PropertyDefinition FromContext(Property_declarationContext context, TypedDefinitionInfo extendedInfo)
        {
            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = AccessorDefinitions.FromContext(context);
            var (name, addressedInterface) = ResolvedName.FromContext(context.member_name().namespace_or_type_name());

            return new PropertyDefinition(
                name: name,
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: extendedInfo.AttributeGroups,
                type: extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                hasRefModifier: extendedInfo.HasRefModifier,
                isStatic: modifiers.IsStatic,
                getter: getter,
                setter: setter,
                addressedInterface: addressedInterface,
                defaultValue: Expression.FromContext(context.variable_initializer()));
        }
    }
}
