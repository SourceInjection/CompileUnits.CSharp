using System.Collections.Generic;

namespace CodeUnits.CSharp.Visitors.ValueTypes
{
    internal readonly struct CommonDefinitionInfo
    {
        public CommonDefinitionInfo(IEnumerable<string> modifiers, List<AttributeGroup> attributeGroups)
        {
            Modifiers = modifiers;
            AttributeGroups = attributeGroups;
        }

        public IEnumerable<string> Modifiers { get; }

        public List<AttributeGroup> AttributeGroups { get; }
    }
}
