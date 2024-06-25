using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public enum TypeKind 
    {
        Enum, 
        Class, 
        Record, 
        Struct,
        Interface, 
        Delegate, 
        Tuple 
    }

    public abstract class TypeDefinition: MemberDefinition
    {
        protected private TypeDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups)

            : base(name, accessModifier, hasNewModifier, attributeGroups)
        { }

        public abstract TypeKind TypeKind { get; }

        public override MemberKind MemberKind { get; } = MemberKind.Type;

        public NamespaceDefinition ContainingNamespace { get; internal set; }

        public string FullName()
        {
            if (ContainingNamespace != null)
                return $"{ContainingNamespace.FullName()}.{Name}";
            if (ContainingType != null)
                return $"{ContainingType.FullName()}.{Name}";
            return Name;
        }
    }
}
