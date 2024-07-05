using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class OperatorDefinition : InvokableMemberDefinition, IOperator
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
            if(addressedInterface != null)
                addressedInterface.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Operator;

        public ITypeUsage AddressedInterface { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            IEnumerable<ITreeNode> result = AttributeGroups;
            if (AddressedInterface != null)
                result = result.Append(AddressedInterface);
            result = result.Append(ReturnType)
                .Concat(Parameters);
            if (Body != null)
                result = result.Append(Body);
            return result;
        }

        internal static OperatorDefinition FromContext(Operator_declarationContext context, ExtendedDefinitionInfo extendedInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new OperatorDefinition(
                name: context.overloadable_operator().GetText(),
                attributeGroups: extendedInfo.AttributeGroups,
                parameters: ParameterDefinitions.FromContext(context),
                returnType: extendedInfo.Type,
                body: CodeFragment.FromContext(context.body()),
                addressedInterface: extendedInfo.AddressedInterface);
        }
    }
}
