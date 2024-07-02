namespace CodeUnits.CSharp
{
    public interface IArgument
    {
        ICodeFragment Expression { get; }

        string TargetedParameter { get; }
    }
}
