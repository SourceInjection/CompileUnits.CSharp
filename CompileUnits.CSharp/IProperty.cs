namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents a property definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties">properties</see>.
    /// </summary>
    public interface IProperty : IMember
    {
        /// <summary>
        /// The type of the property.
        /// </summary>
        ITypeUsage Type { get; }

        /// <summary>
        /// The inheritance modifier of the property.
        /// </summary>
        InheritanceModifier InheritanceModifier { get; }

        /// <summary>
        /// If the property has a <see langword="ref"/> this is <see langword="true"/>.
        /// </summary>
        bool HasRefModifier { get; }

        /// <summary>
        /// The <see langword="get"/> accessor of the property.<br/>
        /// This might be <see langword="null"/> since properties can be write only.
        /// </summary>
        IAccessor Getter { get; }

        /// <summary>
        /// The <see langword="set"/> accessor of the property.<br/>
        /// This might be <see langword="null"/> since properties can be read only.
        /// </summary>
        IAccessor Setter { get; }

        /// <summary>
        /// If the property has a <see langword="new"/> this is <see langword="true"/>.
        /// </summary>
        bool HasNewModifier { get; }

        /// <summary>
        /// If the property has the <see langword="static"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// Represents the addressed interface <see langword="interface"/>.<br/>
        /// E.g.: public int IMyInterface.MyProperty { get; }.<br/>
        /// This might be <see langword="null"/> since this is only necessary when multiple interfaces expect the same members.
        /// </summary>
        ITypeUsage AddressedInterface { get; }

        /// <summary>
        /// The initial value of a property.<br/>
        /// This might be <see langword="null"/> since property initialization is optional.
        /// </summary>
        IExpression Initialization { get; }
    }
}
