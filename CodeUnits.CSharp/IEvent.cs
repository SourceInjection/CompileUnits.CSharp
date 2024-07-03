namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a <see langword="event"/> definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/event">event</see>,
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/add">add keyword</see>
    /// and <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/remove">remove keyword</see>
    /// </summary>
    public interface IEvent : IMember
    {
        /// <summary>
        /// If the event has a <see langword="new"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool HasNewModifier { get; }

        /// <summary>
        /// If the event has a <see langword="static"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool HasStaticModifier { get; }

        /// <summary>
        /// The inheritance modifier of the event.
        /// </summary>
        InheritanceModifier InheritanceModifier { get; }

        /// <summary>
        /// The <see langword="add"/> accessor of the event if defined.<br/>
        /// This might be <see langword="null"/> since accessors are optional.
        /// </summary>
        IAccessor AddAccessor { get; }

        /// <summary>
        /// The <see langword="remove"/> accessor of the event if defined.<br/>
        /// This might be <see langword="null"/> since accessors are optional.
        /// </summary>
        IAccessor RemoveAccessor { get; }
    }
}
