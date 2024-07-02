namespace CodeUnits.CSharp
{
    public interface IIndexer : IMember
    {
        ITypeUsage Type { get; }

        InheritanceModifier InheritanceModifier { get; }

        bool HasRefModifier { get; }

        IAccessor Getter { get; }

        IAccessor Setter { get; }

        bool HasNewModifier { get; }

        ITypeUsage AddressedInterface { get; }
    }
}
