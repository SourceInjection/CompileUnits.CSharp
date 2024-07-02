namespace CodeUnits.CSharp.Implementation.Parameters
{
    public sealed class Argument: IArgument
    {
        internal Argument(CodeFragment expression, string targetedParameter = null)
        {
            Expression = expression;
            TargetedParameter = targetedParameter;
        }

        public ICodeFragment Expression { get; }

        public string TargetedParameter { get; }
    }
}
