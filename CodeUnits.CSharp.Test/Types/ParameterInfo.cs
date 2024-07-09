namespace CodeUnits.CSharp.Test.Types
{
    internal class ParameterInfo(string type, string name, ParameterModifier modifier)
    {
        public string Type { get; } = type;

        public string Name { get; } = name;

        public ParameterModifier Modifier { get; } = modifier;
    }
}
