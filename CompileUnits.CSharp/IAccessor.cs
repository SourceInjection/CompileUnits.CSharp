namespace CompileUnits.CSharp
{
    /// <summary>
    /// This interface represents accessors like <see langword="get"/> and <see langword="set"/> of properties 
    /// and <see langword="add"/> and <see langword="remove"/> of event handlers.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties">properties</see>,
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/add">keyword add</see>
    /// and <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/remove">keyword remove</see>.
    /// </summary>
    public interface IAccessor: IAttributeable
    {
        /// <summary>
        /// The name modifier of the accessor.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The access modifier of the accessor.
        /// </summary>
        AccessModifier AccessModifier { get; }

        /// <summary>
        /// The accessor kind.
        /// </summary>
        AccessorKind Kind { get; }

        /// <summary>
        /// The body of the accessor.<br/>
        /// This might be <see langword="null"/> since accessors don't have to declare a body.
        /// </summary>
        IBody Body { get; }
    }

    public static class IAccessorExtensions
    {
        /// <summary>
        /// Checks if the <see cref="IAccessor"/> is of the desired <see cref="AccessorKind"/>.
        /// </summary>
        /// <param name="accessor">The accessor to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the accessor is of the given kind else <see langword="false"/></returns>
        public static bool IsKind(this IAccessor accessor, AccessorKind kind) => accessor.Kind == kind;
    }
}
