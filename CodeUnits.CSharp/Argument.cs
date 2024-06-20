namespace CodeUnits.CSharp
{
    public class Argument
    {
        public Argument(string expression, string label = null)
        {
            Expression = expression;
            Label = label;
        }

        public string Expression { get; }

        public string Label { get; }
    }
}
