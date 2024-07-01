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
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments, 
            IReadOnlyList<ParameterDefinition> parameters,
            TypeUsage returnType, 
            InheritanceModifier inheritanceModifier,
            Code body,
            TypeUsage addressedInterface)

            : base(
                  name:            name,
                  modifier:        accessModifier, 
                  attributeGroups: attributeGroups, 
                  returnType:      returnType,  
                  parameters:      parameters, 
                  body:            body)
        {
            GenericTypeArguments = genericTypeArguments;
            HasNewModifier = hasNewModifier;
            AddressedInterface = addressedInterface;
            InheritanceModifier = inheritanceModifier;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Method;

        public IReadOnlyList<GenericTypeArgumentDefinition> GenericTypeArguments { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasNewModifier { get; }

        public TypeUsage AddressedInterface { get; }
    }
}
