using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation.Usings
{
    internal class UsingStaticDirectiveDefinition : UsingDirectiveDefinition, IUsingStaticDirective
    {
        internal UsingStaticDirectiveDefinition(TypeUsage type)
        {
            Type = type;
            type.ParentNode = this;
        }

        public ITypeUsage Type { get; }

        public override UsingDirectiveKind Kind { get; } = UsingDirectiveKind.Static;

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            yield return Type;
        }
    }
}
