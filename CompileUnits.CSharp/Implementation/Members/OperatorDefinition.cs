using CompileUnits.CSharp.Implementation.Attributes;
using CompileUnits.CSharp.Implementation.Common;
using CompileUnits.CSharp.Implementation.Parameters;
using System.Collections.Generic;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation.Members
{
    internal class OperatorDefinition : InvokableMemberDefinition, IOperator
    {
        internal OperatorDefinition(
            string name,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<ParameterDefinition> parameters,
            TypeUsage returnType,
            Body body,
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

        internal static OperatorDefinition FromContext(Operator_declarationContext context, TypedDefinitionInfo extendedInfo)
        {
            return new OperatorDefinition(
                name: context.overloadable_operator().GetText(),
                attributeGroups: extendedInfo.AttributeGroups,
                parameters: ParameterDefinitions.FromContext(context),
                returnType: extendedInfo.Type,
                body: Implementation.Body.FromContext(context.body()),
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
