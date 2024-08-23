using CompileUnits.CSharp.Implementation.Attributes;
using CompileUnits.CSharp.Implementation.Common;
using CompileUnits.CSharp.Implementation.Members.Minor;
using System.Collections.Generic;
using System.Linq;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation.Members.Types
{
    internal class EnumDefinition : TypeDefinition, IEnum
    {
        internal EnumDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<EnumMemberDefinition> members,
            TypeUsage baseType)

            : base(
                  name: name,
                  accessModifier: accessModifier,
                  hasNewModifier: hasNewModifier,
                  attributeGroups: attributeGroups)
        {
            Members = members;
            BaseType = baseType;

            foreach (var member in members)
                member.ContainingType = this;
            if(baseType != null)
                baseType.ParentNode = this;
        }

        public IReadOnlyList<IEnumMember> Members { get; }

        public override TypeKind TypeKind { get; } = TypeKind.Enum;

        public ITypeUsage BaseType { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            var result = base.ChildNodes();
            if(BaseType != null)
                result = result.Append(BaseType);
            return result.Concat(Members);
        }

        internal static EnumDefinition FromContext(Enum_definitionContext context, CommonDefinitionInfo commonInfo)
        {
            var modifiers = Modifiers.OfEnum(commonInfo.Modifiers);

            return new EnumDefinition(
                name: context.identifier().GetText(),
                accessModifier: modifiers.AccessModifier,
                hasNewModifier: modifiers.HasNewModifier,
                attributeGroups: commonInfo.AttributeGroups,
                members: EnumMemberDefinitions.FromContext(context.enum_body()),
                baseType: TypeUsage.FromContext(context.enum_base()?.enum_base_type()));
        }
    }
}
