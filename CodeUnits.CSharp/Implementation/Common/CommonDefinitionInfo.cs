using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Common
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
