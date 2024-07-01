using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    public sealed class ClassDefinition: StructuredTypeDefinition
    {
        internal ClassDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<MemberDefinition> members,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints,
            bool isRecord,
            bool isStatic,
            bool isSealed,
            bool isAbstract)

            : base(
                  name:                 name, 
                  accessModifier:       accessModifier,
                  hasNewModifier:       hasNewModifier, 
                  attributeGroups:      attributeGroups, 
                  members:              members, 
                  genericTypeArguments: genericTypeArguments, 
                  constraints:          constraints)
        {
            IsStatic = isStatic;
            IsRecord = isRecord;
            IsSealed = isSealed;
            IsAbstract = isAbstract;
            Destructor = members.OfType<DestructorDefinition>()
                .SingleOrDefault();
        }

        public override TypeKind TypeKind { get; } = TypeKind.Class;

        public bool IsStatic { get; }

        public bool IsRecord { get; }

        public bool IsSealed { get; }

        public bool IsAbstract { get; }

        public DestructorDefinition Destructor { get; }
    }
}
