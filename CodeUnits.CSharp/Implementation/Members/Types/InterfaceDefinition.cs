using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    internal class InterfaceDefinition : StructuredTypeDefinition, IInterface
    {
        internal InterfaceDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<MemberDefinition> members,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints,
            IReadOnlyList<TypeUsage> inheritance)

            : base(
                  name: name,
                  accessModifier: accessModifier,
                  hasNewModifier: hasNewModifier,
                  attributeGroups: attributeGroups,
                  members: members,
                  genericTypeArguments: genericTypeArguments,
                  constraints: constraints,
                  inheritance: inheritance)
        { }

        public override TypeKind TypeKind { get; } = TypeKind.Interface;

        internal static InterfaceDefinition FromContext(Interface_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            var modifiers = Modifiers.OfInterface(commonInfo.Modifiers);
            var genericTypeArguments = GenericTypeArgumentDefinitions.FromContext(context.variant_type_parameter_list());

            return new InterfaceDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: MemberDefinitions.FromContext(context.class_body()),
                genericTypeArguments: genericTypeArguments,
                constraints: ConstraintDefinitions.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments),
                inheritance: TypeUsages.FromContext(context.interface_base()?.interface_type_list()).ToArray());
        }
    }
}
