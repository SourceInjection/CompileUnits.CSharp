using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members.Minor;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class ConstructorDefinition : InvokableMemberDefinition, IConstructor
    {
        internal ConstructorDefinition(
            AccessModifier accessModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<ParameterDefinition> parameters,
            CodeFragment body,
            ConstructorInitializer initializer)

            : base(
                  name: string.Empty,
                  modifier: accessModifier,
                  attributeGroups: attributeGroups,
                  returnType: null,
                  parameters: parameters,
                  body: body)
        {
            Initializer = initializer;
            body.ParentNode = this;
            if (initializer != null)
                initializer.ParentNode = this;
        }

        public override IType ContainingType
        {
            get => base.ContainingType;
            internal set
            {
                base.ContainingType = value;
                var returnType = TypeUsage.FromSymbol(new TerminalSymbol(TerminalSymbolKind.Identifier, value.Name));
                ReturnType = returnType;
                returnType.ParentNode = this;
            }
        }
        public override MemberKind MemberKind { get; } = MemberKind.Constructor;

        public IConstructorInitializer Initializer { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            var result = ((IReadOnlyList<ITreeNode>)AttributeGroups)
                .Append(ReturnType)
                .Concat(Parameters);
            if (Initializer != null)
                result = result.Append(Initializer);
            if (Body != null)
                result = result.Append(Body);
            return result;
        }

        internal static ConstructorDefinition FromContext(Constructor_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var accessModifier = Modifiers.Accessibility(commonInfo.Modifiers);
            var parameters = ParameterDefinitions.FromContext(context.formal_parameter_list());
            var body = CodeFragment.FromContext(context.body());
            var initializer = context.constructor_initializer() == null
                ? null
                : GetInitializer(context.constructor_initializer());

            return new ConstructorDefinition(accessModifier: accessModifier,
                attributeGroups: commonInfo.AttributeGroups,
                parameters: parameters,
                body: body,
                initializer: initializer);
        }

        private static ConstructorInitializer GetInitializer(Constructor_initializerContext context)
        {
            var kind = context.THIS() == null
                ? ConstructorInitializerKind.Base
                : ConstructorInitializerKind.This;
            var arguments = Arguments.FromContext(context.argument_list()).ToArray();

            return new ConstructorInitializer(kind, arguments);
        }
    }
}
