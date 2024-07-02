namespace CodeUnits.CSharp
{
    public interface IConstructor : IInvokableMember
    {
        IConstructorInitializer Initializer { get; }
    }
}
