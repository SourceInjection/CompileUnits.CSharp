using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class IndexerDefinition : PropertyDefinition
    {
        internal IndexerDefinition(
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type, 
            bool isAbstract, 
            bool isVirtual, 
            bool isOverride, 
            bool hasRefModifier, 
            GetterDefinition getter, 
            SetterDefinition setter) 
            
            : base("[]", accessModifier, hasNewModifier, attributeGroups, type, 
                  isAbstract, isVirtual, isOverride, hasRefModifier, 
                  getter, setter)
        { }

        public override MemberKind MemberKind { get; } = MemberKind.Indexer;
    }
}
