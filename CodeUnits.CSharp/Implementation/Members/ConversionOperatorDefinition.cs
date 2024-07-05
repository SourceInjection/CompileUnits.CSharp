using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class ConversionOperatorDefinition : MemberDefinition, IConversionOperator
    {
        internal ConversionOperatorDefinition(
            IReadOnlyList<AttributeGroup> attributeGroups,
            ConversionKind kind,
            TypeUsage returnType,
            ParameterDefinition parameter,
            CodeFragment body)

            : base(name: returnType.FormatedText,
                  modifier: AccessModifier.Public,
                  attributeGroups: attributeGroups)
        {
            Kind = kind;
            Parameter = parameter;
            ReturnType = returnType;
            Body = body;
        }

        public override MemberKind MemberKind { get; } = MemberKind.ConversionOperator;

        public ConversionKind Kind { get; }

        public IParameter Parameter { get; }

        public ITypeUsage ReturnType { get; }

        public ICodeFragment Body { get; }

        internal static ConversionOperatorDefinition FromContext(Conversion_operator_declaratorContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var kind = context.IMPLICIT() == null
                ? ConversionKind.Explicit
                : ConversionKind.Implicit;

            var type = TypeUsage.FromContext(context.type_());
            var parameter = ParameterDefinition.FromContext(context.arg_declaration());
            var body = CodeFragment.FromContext(context.body());

            return new ConversionOperatorDefinition(
                attributeGroups: commonInfo.AttributeGroups,
                kind: kind,
                returnType: type,
                parameter: parameter,
                body: body);
        }
    }
}
