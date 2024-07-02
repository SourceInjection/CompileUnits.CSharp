using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IMethod : IInvokableMember
    {
        IReadOnlyList<IGenericTypeArgument> GenericTypeArguments { get; }

        InheritanceModifier InheritanceModifier { get; }

        bool HasNewModifier { get; }

        ITypeUsage AddressedInterface { get; }
    }
}
