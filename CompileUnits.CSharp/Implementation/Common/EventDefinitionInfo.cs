using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Attributes;

namespace CompileUnits.CSharp.Implementation.Common
{
    internal readonly struct EventDefinitionInfo
    {
        public EventDefinitionInfo(CommonDefinitionInfo commonInfo, TypeUsage type)
        {
            Modifiers = commonInfo.Modifiers;
            AttributeGroups = commonInfo.AttributeGroups;
            Type = type;
        }

        public IEnumerable<string> Modifiers { get; }

        public List<AttributeGroup> AttributeGroups { get; }

        public TypeUsage Type { get; }
    }
}
