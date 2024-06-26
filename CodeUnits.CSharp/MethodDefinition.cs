using System.Collections.Generic;
namespace CodeUnits.CSharp
{
    public sealed class MethodDefinition: InvokableMemberDefinition
    {
        internal MethodDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<string> genericTypeArguments, 
            IReadOnlyList<ParameterDefinition> parameters,
            TypeUsage returnType, 
            Code body,
            bool isAbstract, 
            bool isVirtual, 
            bool isOverride, 
            bool isSealed)

            : base(name, accessModifier, attributeGroups, returnType, parameters, body)
        {
            GenericTypeArguments = genericTypeArguments;
            IsAbstract = isAbstract;
            IsVirtual = isVirtual;
            IsOverride = isOverride;
            IsSealed = isSealed;
            HasNewModifier = hasNewModifier;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Method;

        public IReadOnlyList<string> GenericTypeArguments { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }

        public bool IsSealed { get; }

        public bool HasNewModifier { get; }
    }
}
