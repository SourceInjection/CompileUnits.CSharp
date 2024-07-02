namespace CodeUnits.CSharp
{
    public interface IType : IMember
    {
        TypeKind TypeKind { get; }

        INamespace ContainingNamespace { get; }

        bool HasNewModifier { get; }
    }
}
