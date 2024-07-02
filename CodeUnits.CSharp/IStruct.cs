namespace CodeUnits.CSharp
{
    public interface IStruct : IStructuredType
    {
        bool IsReadonly { get; }

        bool IsRecord { get; }
    }
}
