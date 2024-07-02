using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    public class OperatorDefinition : InvokableMemberDefinition, IOperator
    {
        internal OperatorDefinition(
            string name,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<ParameterDefinition> parameters,
            TypeUsage returnType,
            CodeFragment body,
            TypeUsage addressedInterface)

            : base(name: name,
                  modifier: AccessModifier.Public,
                  attributeGroups: attributeGroups,
                  returnType: returnType,
                  parameters: parameters,
                  body: body)
        {
            AddressedInterface = addressedInterface;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Operator;

        public ITypeUsage AddressedInterface { get; }

        internal static OperatorDefinition FromContext(Operator_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new OperatorDefinition(
                name: context.overloadable_operator().GetText(),
                attributeGroups: extendedInfo.AttributeGroups,
                parameters: ParameterDefinitionss.FromContext(context),
                returnType: extendedInfo.Type,
                body: CodeFragment.FromContext(context.body()),
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
