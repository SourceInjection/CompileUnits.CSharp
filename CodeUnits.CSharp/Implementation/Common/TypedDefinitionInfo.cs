using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Common
{
    internal readonly struct TypedDefinitionInfo
    {
        public TypedDefinitionInfo(CommonDefinitionInfo commonInfo, bool isReadonly, bool hasRefModifier, TypeUsage type, TypeUsage addressedInterface)
        {
            IsReadonly = isReadonly;
            HasRefModifier = hasRefModifier;
            Modifiers = commonInfo.Modifiers;
            AttributeGroups = commonInfo.AttributeGroups;
            Type = type;
            AddressedInterface = addressedInterface;
        }

        public TypedDefinitionInfo(CommonDefinitionInfo commonInfo)
            : this(commonInfo, false, false, TypeUsage.Void, null)
        { }

        public TypeUsage AddressedInterface { get; }

        public bool IsReadonly { get; }

        public bool HasRefModifier { get; }

        public TypeUsage Type { get; }

        public IEnumerable<string> Modifiers { get; }

        public List<AttributeGroup> AttributeGroups { get; }
    }
}
