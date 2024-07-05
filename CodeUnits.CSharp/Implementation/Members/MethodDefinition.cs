using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;
namespace CodeUnits.CSharp.Implementation.Members
{
    internal class MethodDefinition : InvokableMemberDefinition, IMethod
    {
        internal MethodDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ParameterDefinition> parameters,
            TypeUsage returnType,
            InheritanceModifier inheritanceModifier,
            CodeFragment body,
            TypeUsage addressedInterface)

            : base(
                  name: name,
                  modifier: accessModifier,
                  attributeGroups: attributeGroups,
                  returnType: returnType,
                  parameters: parameters,
                  body: body)
        {
            GenericTypeParameters = genericTypeArguments;
            HasNewModifier = hasNewModifier;
            AddressedInterface = addressedInterface;
            InheritanceModifier = inheritanceModifier;
            foreach (var genArg in genericTypeArguments)
                genArg.ParentNode = this;
            if(addressedInterface != null)
                addressedInterface.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Method;

        public IReadOnlyList<IGenericTypeParameter> GenericTypeParameters { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasNewModifier { get; }

        public ITypeUsage AddressedInterface { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            IEnumerable<ITreeNode> result = AttributeGroups;
            if(AddressedInterface != null)
                result = result.Append(AddressedInterface);
            result = result.Append(ReturnType)
                .Concat(GenericTypeParameters)
                .Concat(Parameters);
            if(Body != null)
                result = result.Append(Body);
            return result;
        }

        internal static MethodDefinition FromContext(Method_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfMethod(extendedInfo.Modifiers);
            var (name, addressedInterface) = ResolvedName.FromContext(context.method_member_name());

            return new MethodDefinition(
                name: name,
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: extendedInfo.AttributeGroups,
                genericTypeArguments: GenericTypeArgumentDefinitions.FromContext(context.type_parameter_list()),
                parameters: ParameterDefinitions.FromContext(context.formal_parameter_list()),
                returnType: extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                body: CodeFragment.FromContext(context.method_body()?.block()),
                addressedInterface: addressedInterface);
        }
    }
}
