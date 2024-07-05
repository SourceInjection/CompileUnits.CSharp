using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation.Usings
{
    internal class UsingAliasDirectiveDefinition : UsingDirectiveDefinition, IUsingAliasDirective
    {
        internal UsingAliasDirectiveDefinition(string name, TypeUsage type)
        {
            Alias = name;
            Type = type;
            type.ParentNode = this;
        }

        public string Alias { get; }

        public ITypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Alias;

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            yield return Type;
        }
    }
}
