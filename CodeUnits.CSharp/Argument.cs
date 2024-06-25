namespace CodeUnits.CSharp
{
    public sealed class Argument
    {
        internal Argument(Expression expression, string targetedParameter = null)
        {
            Expression = expression;
            TargetedParameter = targetedParameter;
        }

        public Expression Expression { get; }

        public string TargetedParameter { get; }
    }
}
