namespace CodeUnits.CSharp
{
    public interface IEvent : IMember
    {
        bool HasNewModifier { get; }

        bool HasStaticModifier { get; }

        InheritanceModifier InheritanceModifier { get; }

        IAccessor AddAccessor { get; }

        IAccessor RemoveAccessor { get; }
    }
}
