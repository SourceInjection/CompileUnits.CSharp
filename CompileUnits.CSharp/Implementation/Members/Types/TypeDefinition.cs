using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Attributes;

namespace CompileUnits.CSharp.Implementation.Members.Types
{
    internal abstract class TypeDefinition : MemberDefinition, IType
    {
        protected private TypeDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups)

            : base(
                  name: name,
                  modifier: accessModifier,
                  attributeGroups: attributeGroups)
        {
            HasNewModifier = hasNewModifier;
        }

        public abstract TypeKind TypeKind { get; }

        public override ITreeNode ParentNode => base.ParentNode ?? ContainingNamespace;

        public override MemberKind MemberKind { get; } = MemberKind.Type;

        public INamespace ContainingNamespace { get; internal set; }

        public bool HasNewModifier { get; }

        public NamespaceMemberKind NamespaceMemberKind { get; } = NamespaceMemberKind.Type;
    }
}
