using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class EventDefinition : MemberDefinition
    {
        public EventDefinition(
            string name, 
            AccessModifier modifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            bool hasNewModifier,
            bool hasStaticModifier,
            InheritanceModifier inheritanceModifier,
            AccessorDefinition addAccessor = null, 
            AccessorDefinition removeAccessor = null)

            : base(
                  name: name,
                  modifier: modifier,
                  attributeGroups: attributeGroups)
        {
            HasNewModifier = hasNewModifier;
            HasStaticModifier = hasStaticModifier;
            InheritanceModifier = inheritanceModifier;
            AddAccessor = addAccessor;
            RemoveAccessor = removeAccessor;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Event;

        public bool HasNewModifier { get; }

        public bool HasStaticModifier { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public AccessorDefinition AddAccessor { get; }

        public AccessorDefinition RemoveAccessor { get; }
    }
}
