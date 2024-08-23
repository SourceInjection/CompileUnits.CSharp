using System.Collections.Generic;
using System.Linq;

namespace CompileUnits.CSharp
{
    public interface ITreeNode
    {
        /// <summary>
        /// The parent node of a tree node.<br/>
        /// This might be <see langword="null"/> since the root element has no parent.
        /// </summary>
        ITreeNode ParentNode { get; }

        /// <summary>
        /// Lists the direct child nodes of the current node.
        /// </summary>
        /// <returns>All direct children of the current node.</returns>
        IEnumerable<ITreeNode> ChildNodes();
    }

    public static class ITreeNodeExtensions
    {
        /// <summary>
        /// Lists all children of the current node.
        /// This is a pre order tree run.
        /// </summary>
        /// <param name="treeNode">The node for which the children are evaluated.</param>
        /// <returns>All children pre order.</returns>
        public static IEnumerable<ITreeNode> AllChildren(this ITreeNode treeNode)
        {
            return treeNode.ChildNodes()
                .SelectMany(c => c.AllChildren().Prepend(c));
        }
    }
}
