using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a method definition.
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods">methods</see>.
    /// </summary>
    public interface IMethod : IInvokableMember
    {
        /// <summary>
        /// Lists the generic type parameters of the method.
        /// </summary>
        IReadOnlyList<IGenericTypeParameter> GenericTypeParameters { get; }

        /// <summary>
        /// The inheritance modifier of the method.
        /// </summary>
        InheritanceModifier InheritanceModifier { get; }

        /// <summary>
        /// If the method has the <see langword="new"/> modifier this is <see langword="true"/>.
        /// </summary>
        bool HasNewModifier { get; }

        /// <summary>
        /// Represents the addressed interface <see langword="interface"/>.<br/>
        /// E.g.: void IMyInterface.MyMethod().<br/>
        /// This might be <see langword="null"/> since this is only necessary when multiple interfaces expect the same members.
        /// </summary>
        ITypeUsage AddressedInterface { get; }
    }
}
