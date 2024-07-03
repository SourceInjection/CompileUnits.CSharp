using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;
using CodeUnits.CSharp.Implementation.Parameters;
using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    internal class DelegateDefinition : TypeDefinition, IDelegate
    {
        internal DelegateDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage returnType,
            IReadOnlyList<ParameterDefinition> parameters,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints)

            : base(
                  name: name,
                  accessModifier: accessModifier,
                  hasNewModifier: hasNewModifier,
                  attributeGroups: attributeGroups)
        {
            ReturnType = returnType;
            Parameters = parameters;
            GenericTypeArguments = genericTypeArguments;
            Constraints = constraints;
        }

        public override TypeKind TypeKind { get; } = TypeKind.Delegate;

        public ITypeUsage ReturnType { get; }

        public IReadOnlyList<IParameter> Parameters { get; }

        public IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        public IReadOnlyList<IConstraint> Constraints { get; }

        internal static DelegateDefinition FromContext(Delegate_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modifiers = Modifiers.OfDelegate(commonInfo.Modifiers);
            var genericTypeArguments = GenericTypeArgumentDefinitions.FromContext(context.variant_type_parameter_list());
            var returnType = context.return_type().type_() is null
                ? TypeUsage.Void
                : new TypeUsage(context.return_type().type_());

            return new DelegateDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                returnType: returnType,
                parameters: ParameterDefinitionss.FromContext(context.formal_parameter_list()),
                genericTypeArguments: genericTypeArguments,
                constraints: ConstraintDefinitions.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments));
        }
    }
}
