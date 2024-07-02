namespace CodeUnits.CSharp
{
    public interface IOperator : IInvokableMember
    {
        ITypeUsage AddressedInterface { get; }
    }
}
