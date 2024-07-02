namespace CodeUnits.CSharp
{
    public interface IExternAlias
    {
        INamespace ContainingNamespace { get; }

        string Name { get; }
    }
}
