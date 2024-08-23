using CompileUnits.CSharp.Implementation.Attributes;
using CompileUnits.CSharp.Implementation.Common;
using CompileUnits.CSharp.Implementation.Members.Types.Generics;
using System.Collections.Generic;
using System.Linq;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation.Members.Types
{
    internal class ClassDefinition : StructuredTypeDefinition, IClass
    {
        private ClassDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<MemberDefinition> members,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints,
            IReadOnlyList<TypeUsage> inheritance,
            bool isRecord,
            bool isStatic,
            bool isSealed,
            bool isAbstract)

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
            IsStatic = isStatic;
            IsRecord = isRecord;
            IsSealed = isSealed;
            IsAbstract = isAbstract;
            Finalizer = members.OfType<FinalizerDefinition>().FirstOrDefault();
        }

        public override TypeKind TypeKind { get; } = TypeKind.Class;

        public bool IsStatic { get; }

        public bool IsRecord { get; }

        public bool IsSealed { get; }

        public bool IsAbstract { get; }

        public IFinalizer Finalizer { get; }

        internal static ClassDefinition FromContext(Class_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            var modifiers = Modifiers.OfClass(commonInfo.Modifiers);
            var genericTypeArguments = GenericTypeArgumentDefinitions.FromContext(context.type_parameter_list());

            return new ClassDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: MemberDefinitions.FromContext(context.class_body()),
                genericTypeArguments: genericTypeArguments,
                constraints: ConstraintDefinitions.FromContext(context.type_parameter_constraints_clauses(), genericTypeArguments),
                isRecord: context.RECORD() != null,
                isStatic: modifiers.IsStatic,
                isSealed: modifiers.IsSealed,
                isAbstract: modifiers.IsAbstract,
                inheritance: TypeUsages.FromContext(context.class_base()).ToArray());
        }
    }
}
