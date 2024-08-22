namespace CodeUnits.CSharp.Test.Members.Types
{
    internal class ParameterInfo
    {
        public ParameterInfo(string type, string name, ParameterModifier modifier)
        {
            Type = type;
            Name = name;
            Modifier = modifier;
        }

        public string Type { get; }

        public string Name { get; }

        public ParameterModifier Modifier { get; }
    }
}
