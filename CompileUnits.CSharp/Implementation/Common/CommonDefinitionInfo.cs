using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Attributes;

namespace CompileUnits.CSharp.Implementation.Common
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
