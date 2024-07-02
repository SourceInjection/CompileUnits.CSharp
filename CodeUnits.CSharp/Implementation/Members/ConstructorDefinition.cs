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
    public sealed class ConstructorDefinition : InvokableMemberDefinition, IConstructor
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
        }

        public override IType ContainingType
        {
            get => base.ContainingType;
            internal set
            {
                base.ContainingType = value;
                if (value != null)
                    ReturnType = new TypeUsage(new TerminalSymbol(TerminalSymbolKind.Identifier, value.Name));
            }
        }
        public override MemberKind MemberKind { get; } = MemberKind.Constructor;

        public IConstructorInitializer Initializer { get; }

        internal static ConstructorDefinition FromContext(Constructor_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var accessModifier = Modifiers.Accessibility(commonInfo.Modifiers);
            var parameters = ParameterDefinitionss.FromContext(context.formal_parameter_list());
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
