using System;
using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    internal class OperatorDefinition : InvokableMemberDefinition
    {
        private protected OperatorDefinition(
            string name, 
            AccessModifier accessModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups, 
            IReadOnlyList<ParameterDefinition> parameters, 
            TypeUsage returnType, 
            Code body) 

            : base(name, accessModifier, attributeGroups,
                  returnType, parameters,  body)
        {
        }

        public override MemberKind MemberKind { get; } = MemberKind.Operator;
    }
}
