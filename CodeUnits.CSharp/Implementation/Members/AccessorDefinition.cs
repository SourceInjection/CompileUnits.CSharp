using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class AccessorDefinition : IAccessor
    {
        internal AccessorDefinition(
            string name,
            AccessModifier accessModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            CodeFragment body,
            AccessorKind kind)
        {
            Name = name;
            AccessModifier = accessModifier;
            AttributeGroups = attributeGroups;
            Body = body;
            Kind = kind;

            foreach(var ag in attributeGroups)
                ag.ParentNode = this;
            if (body != null)
                body.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public string Name { get; }

        public AccessModifier AccessModifier { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public AccessorKind Kind { get; }

        public ICodeFragment Body { get; }

        public IEnumerable<ITreeNode> ChildNodes()
        {
            IEnumerable<ITreeNode> result = AttributeGroups;
            if (Body != null)
                result = result.Append(Body);
            return result;
        }

        internal static AccessorDefinition FromContext(Set_accessor_declarationContext context)
        {
            if (context == null)
                return null;

            return new AccessorDefinition(
                name: "set",
                accessModifier: GetAccessModifier(context.accessor_modifier()),
                attributeGroups: Attributes.AttributeGroups.FromContext(context.attributes()),
                body: CodeFragment.FromContext(context.accessor_body()?.block()),
                kind: AccessorKind.Setter);
        }

        internal static AccessorDefinition FromContext(Get_accessor_declarationContext context)
        {
            if (context == null)
                return null;

            return new AccessorDefinition(
                name: "get",
                accessModifier: GetAccessModifier(context.accessor_modifier()),
                attributeGroups: Attributes.AttributeGroups.FromContext(context.attributes()),
                body: CodeFragment.FromContext(context.accessor_body()?.block()),
                kind: AccessorKind.Getter);
        }

        internal static AccessModifier GetAccessModifier(Accessor_modifierContext context)
        {
            AccessModifier modifier = AccessModifier.None;
            if (context != null)
            {
                var modifiers = new List<string>();
                for (int i = 0; i < context.ChildCount; i++)
                    modifiers.Add(context.GetChild(i).GetText());
                modifier = Modifiers.Accessibility(modifiers);
            }
            return modifier;
        }
    }
}
