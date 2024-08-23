namespace CompileUnits.CSharp
{
    /// <summary>
    /// Represents an overloadable <see langword="operator"/>.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading">operator overloading</see>.
    /// </summary>
    public interface IOperator : IInvokableMember
    {
        /// <summary>
        /// Represents the addressed interface <see langword="interface"/>.<br/>
        /// E.g.: public static int IMyInterface.operator +(IMyInterface lhs, int rhs).<br/>
        /// This might be <see langword="null"/> since this is only necessary when multiple interfaces expect the same members.
        /// </summary>
        ITypeUsage AddressedInterface { get; }
    }
}
