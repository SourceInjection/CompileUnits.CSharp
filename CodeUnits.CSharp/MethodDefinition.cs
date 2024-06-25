using System.Collections.Generic;
namespace CodeUnits.CSharp
{
    public class MethodDefinition: MemberDefinition
    {
        protected private MethodDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<string> genericTypeArguments, 
            IReadOnlyList<ParameterDefinition> parameters,
            TypeUsage returnType, 
            bool isAbstract, 
            bool isVirtual, 
            bool isOverride, 
            bool isNew, 
            bool isSealed,
            MethodBody body)

            : base(name, accessModifier, hasNewModifier, attributeGroups)
        {
            GenericTypeArguments = genericTypeArguments;
            Parameters = parameters;
            ReturnType = returnType;
            IsAbstract = isAbstract;
            IsVirtual = isVirtual;
            IsOverride = isOverride;
            IsNew = isNew;
            IsSealed = isSealed;
            Body = body;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Method;

        public TypeUsage ReturnType { get; }

        public IReadOnlyList<ParameterDefinition> Parameters { get; }

        public IReadOnlyList<string> GenericTypeArguments { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }

        public bool IsNew { get; }

        public bool IsSealed { get; }

        public MethodBody Body { get; }
    }
}
