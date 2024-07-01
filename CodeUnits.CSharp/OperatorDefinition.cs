using System;
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class OperatorDefinition : InvokableMemberDefinition
    {
        internal OperatorDefinition(
            string name, 
            IReadOnlyList<AttributeGroup> attributeGroups, 
            IReadOnlyList<ParameterDefinition> parameters, 
            TypeUsage returnType, 
            Code body,
            TypeUsage addressedInterface) 

            : base(name:           name, 
                  modifier:        AccessModifier.Public, 
                  attributeGroups: attributeGroups,
                  returnType:      returnType, 
                  parameters:      parameters,  
                  body:            body)
        {
            AddressedInterface = addressedInterface;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Operator;

        public TypeUsage AddressedInterface { get; }
    }
}
