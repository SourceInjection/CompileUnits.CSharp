using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents an invokable member.
    /// Constructors, methods, destructors and operators are invokable members.
    /// </summary>
    public interface IInvokableMember : IMember
    {
        /// <summary>
        /// Lists the parameters defined in the parameter list.
        /// </summary>
        IReadOnlyList<IParameter> Parameters { get; }

        /// <summary>
        /// The return type of the invokable member.
        /// </summary>
        ITypeUsage ReturnType { get; }

        /// <summary>
        /// The body of the invokable member.
        /// This might be <see langword="null"/> since a body is optional.
        /// </summary>
        IBody Body { get; }
    }
}
