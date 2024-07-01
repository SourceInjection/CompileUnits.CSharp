using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public abstract class InvokableMemberDefinition : MemberDefinition
    {
        private protected InvokableMemberDefinition(
            string name, 
            AccessModifier modifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage returnType,
            IReadOnlyList<ParameterDefinition> parameters,
            Code body) 
            
            : base(
                  name:            name, 
                  modifier:        modifier, 
                  attributeGroups: attributeGroups)
        {
            ReturnType = returnType;
            Body = body;
            Parameters = parameters;
        }

        public IReadOnlyList<ParameterDefinition> Parameters { get; }

        public TypeUsage ReturnType { get; protected private set; }

        public Code Body { get; }
    }
}
