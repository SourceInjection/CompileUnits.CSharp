using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    public enum InheritanceModifier
    {
        None,
        Sealed,
        Virtual,
        Abstract,
    }

    public enum MemberKind
    {
        Type,
        Property,
        Field,
        Method,
        Destructor,
        Constructor,
        Operator,
        ConversionOperator,
        Indexer,
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
        protected private MemberDefinition(string name, AccessModifier modifier, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            AccessModifier = modifier;
            AttributeGroups = attributeGroups;
            Attributes = attributeGroups.SelectMany(a => a.Attributes).ToArray();
        }

        public abstract MemberKind MemberKind { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<AttributeUsage> Attributes { get; }

        public virtual TypeDefinition ContainingType { get; internal set; }

        public string Name { get; }

        public AccessModifier AccessModifier { get; }

        public bool IsKind(MemberKind kind) => MemberKind == kind;

        public bool HasAccessibility(AccessModifier accessModifier)
        {
            return accessModifier == AccessModifier;
        }
    }
}
