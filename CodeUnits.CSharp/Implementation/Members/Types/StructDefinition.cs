using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    internal class StructDefinition : StructuredTypeDefinition, IStruct
    {
        internal StructDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<MemberDefinition> members,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints,
            IReadOnlyList<TypeUsage> inheritance,
            bool isRecord, 
            bool isReadonly)

            : base(
                  name: name,
                  accessModifier: accessModifier,
                  hasNewModifier: hasNewModifier,
                  attributeGroups: attributeGroups,
                  members: members,
                  genericTypeArguments: genericTypeArguments,
                  constraints: constraints,
                  inheritance: inheritance)
        {
            IsRecord = isRecord;
            IsReadonly = isReadonly;
        }

        public override TypeKind TypeKind { get; } = TypeKind.Struct;

        public bool IsReadonly { get; }

        public bool IsRecord { get; }

        internal static StructDefinition FromContext(Struct_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            var modifiers = Modifiers.OfStruct(commonInfo.Modifiers);
            var isRecord = context.RECORD() != null;
            var genericTypeArguments = GenericTypeArgumentDefinitions.FromContext(context.type_parameter_list());

            return new StructDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: MemberDefinitions.FromContext(context.struct_body()),
                genericTypeArguments: genericTypeArguments,
                constraints: ConstraintDefinitions.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments),
                isRecord: isRecord,
                isReadonly: modifiers.IsReadonly,
                inheritance: TypeUsages.FromContext(context.interface_base()).ToArray());
        }
    }
}
