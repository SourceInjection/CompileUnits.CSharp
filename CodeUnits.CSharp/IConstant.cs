namespace CodeUnits.CSharp
{
    public interface IConstant : IMember
    {
        ITypeUsage Type { get; }

        ICodeFragment Value { get; }

        bool HasNewModifier { get; }
    }
}
