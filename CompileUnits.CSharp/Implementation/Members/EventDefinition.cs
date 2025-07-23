using System.Collections.Generic;
using System.Linq;
using CompileUnits.CSharp.Implementation.Attributes;

namespace CompileUnits.CSharp.Implementation.Members
{
    internal class EventDefinition : MemberDefinition, IEvent
    {
        public EventDefinition(
            string name,
            TypeUsage type,
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
            Type = type;

            if (addAccessor != null)
                addAccessor.ParentNode = this;
            if(removeAccessor != null)
                removeAccessor.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Event;

        public ITypeUsage Type { get; }

        public bool HasNewModifier { get; }

        public bool HasStaticModifier { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public IAccessor AddAccessor { get; }

        public IAccessor RemoveAccessor { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            var result = base.ChildNodes();
            if(AddAccessor != null)
                result = result.Append(AddAccessor);
            if(RemoveAccessor != null)
                result = result.Append(RemoveAccessor);
            return result;
        }
    }
}
