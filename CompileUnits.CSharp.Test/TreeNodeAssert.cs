namespace CompileUnits.CSharp.Test
{
    internal static class TreeNodeAssert
    {
        internal static void LinksAreValid(ITreeNode node)
        {
            Assert.Multiple(() =>
            {
                Assert.That(node.ChildNodes().Any(child => child == null), Is.False);
                Assert.That(node.ChildNodes().All(child => child.ParentNode == node), Is.True);
                if (node is ICompileUnit)
                    return;
                Assert.That(node.ParentNode.ChildNodes(), Does.Contain(node));
            });
        }
    }
}
