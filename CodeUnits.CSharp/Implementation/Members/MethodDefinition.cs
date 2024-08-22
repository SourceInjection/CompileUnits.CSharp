using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;
using CodeUnits.CSharp.Implementation.Parameters;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;
namespace CodeUnits.CSharp.Implementation.Members
{
    internal class MethodDefinition : InvokableMemberDefinition, IMethod
    {
        internal MethodDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            bool isStatic,
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
            IsStatic = isStatic;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Method;

        public IReadOnlyList<IGenericTypeParameter> GenericTypeParameters { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasNewModifier { get; }

        public bool IsStatic { get; }

        public ITypeUsage AddressedInterface { get; }

        internal static MethodDefinition FromContext(Method_declarationContext context, TypedDefinitionInfo extendedInfo)
        {
            var modifiers = Modifiers.OfMethod(extendedInfo.Modifiers);
            var (name, addressedInterface) = ResolvedName.FromContext(context.method_member_name());

            return new MethodDefinition(
                name: name,
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                isStatic: modifiers.IsStatic,
                attributeGroups: extendedInfo.AttributeGroups,
                genericTypeArguments: GenericTypeArgumentDefinitions.FromContext(context.type_parameter_list()),
                parameters: ParameterDefinitions.FromContext(context.formal_parameter_list()),
                returnType: extendedInfo.Type,
                inheritanceModifier: modifiers.InheritanceModifier,
                body: GetBody(context),
                addressedInterface: addressedInterface);
        }

        private static CodeFragment GetBody(Method_declarationContext context)
        {
            if (context.method_body()?.block() != null)
                return CodeFragment.FromContext(context.method_body().block());
            if (context.throwable_expression() != null)
                return CodeFragment.FromContext(context.throwable_expression());
            return null;
        }
    }
}
