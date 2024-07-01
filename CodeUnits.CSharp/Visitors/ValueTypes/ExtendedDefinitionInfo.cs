using System.Collections.Generic;

namespace CodeUnits.CSharp.Visitors.ValueTypes
{
    internal readonly struct ExtendedDefinitionInfo
    {
        public ExtendedDefinitionInfo(CommonDefinitionInfo commonInfo, bool isReadonly, bool hasRefModifier, TypeUsage type, TypeUsage addressedInterface)
        {
            IsReadonly = isReadonly;
            HasRefModifier = hasRefModifier;
            Modifiers = commonInfo.Modifiers;
            AttributeGroups = commonInfo.AttributeGroups;
            Type = type;
            AddressedInterface = addressedInterface;
        }

        public TypeUsage AddressedInterface { get; }

        public bool IsReadonly { get; }

        public bool HasRefModifier { get; }

        public TypeUsage Type { get; }

        public IEnumerable<string> Modifiers { get; }

        public List<AttributeGroup> AttributeGroups { get; }
    }
}
