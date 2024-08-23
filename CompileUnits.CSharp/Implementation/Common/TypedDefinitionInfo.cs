using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Attributes;

namespace CompileUnits.CSharp.Implementation.Common
{
    internal readonly struct TypedDefinitionInfo
    {
        public TypedDefinitionInfo(CommonDefinitionInfo commonInfo, bool hasRefModifier, TypeUsage type, TypeUsage addressedInterface)
        {
            HasRefModifier = hasRefModifier;
            Modifiers = commonInfo.Modifiers;
            AttributeGroups = commonInfo.AttributeGroups;
            Type = type;
            AddressedInterface = addressedInterface;
        }

        public TypedDefinitionInfo(CommonDefinitionInfo commonInfo)
            : this(commonInfo, false, TypeUsage.Void, null)
        { }

        public TypeUsage AddressedInterface { get; }

        public bool HasRefModifier { get; }

        public TypeUsage Type { get; }

        public IEnumerable<string> Modifiers { get; }

        public List<AttributeGroup> AttributeGroups { get; }
    }
}
