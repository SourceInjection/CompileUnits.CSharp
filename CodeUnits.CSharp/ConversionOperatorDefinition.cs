using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public enum ConversionOperatorKind { Implicit, Explicit };

    internal class ConversionOperatorDefinition : OperatorDefinition
    {
        internal ConversionOperatorDefinition(
            string name, 
            IReadOnlyList<AttributeGroup> attributeGroups, 
            IReadOnlyList<ParameterDefinition> parameters, 
            TypeUsage returnType, 
            Code body, 
            TypeUsage addressedInterface,
            ConversionOperatorKind kind) 
            
            : base(
                  name: name,
                  attributeGroups: attributeGroups,
                  parameters: parameters, 
                  returnType: returnType, 
                  body: body, 
                  addressedInterface: addressedInterface)
        {
            Kind = kind;
        }

        public override MemberKind MemberKind { get; } = MemberKind.ConversionOperator;

        public ConversionOperatorKind Kind { get; }
    }
}
