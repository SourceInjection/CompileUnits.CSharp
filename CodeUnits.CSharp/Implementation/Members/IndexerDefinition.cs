using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IReadOnlyList<ParameterDefinition> parameters,
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
            type.ParentNode = this;
            if (getter != null)
                getter.ParentNode = this;
            if(setter != null)
                setter.ParentNode = this;
            if(addressedInterface != null)
                addressedInterface.ParentNode = this;
            foreach(var parameter in parameters)
                parameter.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Indexer;

        public ITypeUsage ReturnType { get; }

        public IReadOnlyList<IParameter> Parameters { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public IAccessor Getter { get; }

        public IAccessor Setter { get; }

        public bool HasNewModifier { get; }

        public ITypeUsage AddressedInterface { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            var result = base.ChildNodes();
            if (AddressedInterface != null)
                result = result.Append(AddressedInterface);
            result = result.Append(ReturnType)
                .Concat(Parameters); 
            if(Getter != null)
                result = result.Append(Getter);
            if(Setter != null)
                result = result.Append(Setter);
            return result;
        }

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
                parameters: ParameterDefinitions.FromContext(context.formal_parameter_list()),
                getter: getter,
                setter: setter,
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
