namespace CodeUnits.CSharp
{
    public interface IUsingAliasDirective : IUsingDirective
    {
        string Name { get; }

        ITypeUsage Type { get; }
    }
}
