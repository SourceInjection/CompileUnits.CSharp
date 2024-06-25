using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    public enum MemberKind
    {
        Type,
        Property,
        Field,
        Method,
        Destructor,
        Constructor,
        Event,
        Constant,
    }

    public enum AccessModifier
    {
        None,
        Private,
        PrivateProtected,
        Internal,
        Protected,
        ProtectedInternal,
        Public
    }

    public abstract class MemberDefinition
    {
        protected private MemberDefinition(string name, AccessModifier modifier, bool hasNewModifier, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            AccessModifier = modifier;
            HasNewModifer = hasNewModifier;
            AttributeGroups = attributeGroups;
            Attributes = attributeGroups.SelectMany(a => a.Attributes).ToArray();
        }

        public abstract MemberKind MemberKind { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<AttributeUsage> Attributes { get; }

        public TypeDefinition ContainingType { get; internal set; }

        public string Name { get; }

        public bool HasNewModifer { get; }

        public AccessModifier AccessModifier { get; }

        public bool IsKind(MemberKind kind) => MemberKind == kind;

        public bool HasAccessibility(AccessModifier accessModifier)
        {
            return accessModifier == AccessModifier;
        }
    }
}
