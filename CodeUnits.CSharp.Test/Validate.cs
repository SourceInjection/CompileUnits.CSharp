namespace CodeUnits.CSharp.Test
{
    internal static class Validate
    {
        internal static void TreeNodeLinks(ITreeNode node)
        {
            Assert.Multiple(() =>
            {
                Assert.That(node.ChildNodes().All(child => child.ParentNode == node), Is.True);
                if (node is ICodeUnit)
                    return;
                Assert.That(node.ParentNode.ChildNodes(), Does.Contain(node));
            });
        }
    }
}
