namespace CodeUnits.CSharp
{
    public interface IClass : IStructuredType
    {
        bool IsStatic { get; }

        bool IsRecord { get; }

        bool IsSealed { get; }

        bool IsAbstract { get; }

        IDestructor Destructor { get; }
    }
}
