using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class DelegateDefinition : TypeDefinition
    {
        internal DelegateDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage returnType, 
            IReadOnlyList<ParameterDefinition> parameters,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments, 
            IReadOnlyList<ConstraintDefinition> constraints)

            : base(
                  name: name, 
                  accessModifier: accessModifier, 
                  hasNewModifier: hasNewModifier, 
                  attributeGroups: attributeGroups)
        {
            ReturnType = returnType;
            Parameters = parameters;
            GenericTypeArguments = genericTypeArguments;
            Constraints = constraints;
        }

        public override TypeKind TypeKind { get; } = TypeKind.Delegate;

        public TypeUsage ReturnType { get; }

        public IReadOnlyList<ParameterDefinition> Parameters { get; }

        public IReadOnlyList<GenericTypeArgumentDefinition> GenericTypeArguments { get; }

        public IReadOnlyList<ConstraintDefinition> Constraints { get; }
    }
}
