﻿using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class PropertyDefinition : MemberDefinition, IProperty
    {
        private PropertyDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            InheritanceModifier inheritanceModifier,
            bool hasRefModifier,
            AccessorDefinition getter,
            AccessorDefinition setter,
            TypeUsage addressedInterface,
            CodeFragment defaultValue)

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
            type.ParentNode = this;
            if (getter != null)
                getter.ParentNode = this;
            if(setter != null)
                setter.ParentNode = this;
            if (defaultValue != null)
                defaultValue.ParentNode = this;
            if (addressedInterface != null)
                addressedInterface.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Property;

        public ITypeUsage Type { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public IAccessor Getter { get; }

        public IAccessor Setter { get; }

        public bool HasNewModifier { get; }

        public ITypeUsage AddressedInterface { get; }

        public ICodeFragment Initialization { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            IEnumerable<ITreeNode> result = AttributeGroups;
            if(AddressedInterface != null)
                result = result.Append(AddressedInterface);
            result = result.Append(Type);
            if(Getter != null)
                result = result.Append(Getter);
            if(Setter != null)
                result = result.Append(Setter);
            if(Initialization != null)
                result = result.Append(Initialization);
            return result;
        }

        internal static PropertyDefinition FromContext(Property_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfIndexer(extendedInfo.Modifiers);
            var (getter, setter) = AccessorDefinitions.FromContext(context);
            var (name, addressedInterface) = ResolvedName.FromContext(context.member_name().namespace_or_type_name());
            CodeFragment defaultValue = null;
            if (context.variable_initializer() != null)
            {
                if (context.variable_initializer().array_initializer() != null)
                    defaultValue = CodeFragment.FromContext(context.variable_initializer().array_initializer());
                else if (context.variable_initializer().expression() != null)
                    defaultValue = CodeFragment.FromContext(context.variable_initializer().expression());
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
