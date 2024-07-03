namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the constructor of a structured type.<br/>
    /// See <see cref="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors">constructors</see>.
    /// </summary>
    public interface IConstructor : IInvokableMember
    {
        /// <summary>
        /// Represents the initializer of a constructor.
        /// E.g.: base(arg1, arg2) or this(arg1, arg2).
        /// </summary>
        IConstructorInitializer Initializer { get; }
    }
}
