using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class EventDefinition : MemberDefinition
    {
        public EventDefinition(string name, AccessModifier modifier, IReadOnlyList<AttributeGroup> attributeGroups) 
            : base(
                  name:            name, 
                  modifier:        modifier, 
                  attributeGroups: attributeGroups)
        {

        }

        public override MemberKind MemberKind { get; } = MemberKind.Event;
    }
}
