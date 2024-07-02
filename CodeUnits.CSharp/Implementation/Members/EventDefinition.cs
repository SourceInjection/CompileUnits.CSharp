using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class EventDefinition : MemberDefinition, IEvent
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

        public IAccessor AddAccessor { get; }

        public IAccessor RemoveAccessor { get; }
    }
}
