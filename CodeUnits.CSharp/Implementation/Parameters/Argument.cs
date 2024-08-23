using System.Collections.Generic;

namespace CodeUnits.CSharp.Implementation.Parameters
{
    internal class Argument: IArgument
    {
        internal Argument(Expression expression, string targetedParameter = null)
        {
            Expression = expression;
            TargetedParameter = targetedParameter;
            expression.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public IExpression Expression { get; }

        public string TargetedParameter { get; }

        public IEnumerable<ITreeNode> ChildNodes()
        {
            yield return Expression;
        }
    }
}
