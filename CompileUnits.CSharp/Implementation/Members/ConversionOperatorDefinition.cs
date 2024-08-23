using CompileUnits.CSharp.Implementation.Attributes;
using CompileUnits.CSharp.Implementation.Common;
using CompileUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation.Members
{
    internal class ConversionOperatorDefinition : MemberDefinition, IConversionOperator
    {
        internal ConversionOperatorDefinition(
            IReadOnlyList<AttributeGroup> attributeGroups,
            ConversionKind kind,
            TypeUsage returnType,
            ParameterDefinition parameter,
            Body body)

            : base(name: returnType.FormatedText,
                  modifier: AccessModifier.Public,
                  attributeGroups: attributeGroups)
        {
            Kind = kind;
            Parameter = parameter;
            ReturnType = returnType;
            Body = body;
            returnType.ParentNode = this;
            parameter.ParentNode = this;
            body.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.ConversionOperator;

        public ConversionKind Kind { get; }

        public IParameter Parameter { get; }

        public ITypeUsage ReturnType { get; }

        public IBody Body { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            return base.ChildNodes()
                .Append(ReturnType)
                .Append(Parameter)
                .Append(Body);
        }

        internal static ConversionOperatorDefinition FromContext(Conversion_operator_declaratorContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var kind = context.IMPLICIT() == null
                ? ConversionKind.Explicit
                : ConversionKind.Implicit;

            var type = TypeUsage.FromContext(context.type_());
            var parameter = ParameterDefinition.FromContext(context.arg_declaration());
            var body = Implementation.Body.FromContext(context.body());

            return new ConversionOperatorDefinition(
                attributeGroups: commonInfo.AttributeGroups,
                kind: kind,
                returnType: type,
                parameter: parameter,
                body: body);
        }
    }
}
