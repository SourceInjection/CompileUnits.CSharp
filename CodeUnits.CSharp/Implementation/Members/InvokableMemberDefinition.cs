using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Parameters;

namespace CodeUnits.CSharp.Implementation.Members
{
    public abstract class InvokableMemberDefinition : MemberDefinition, IInvokableMember
    {
        private protected InvokableMemberDefinition(
            string name,
            AccessModifier modifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage returnType,
            IReadOnlyList<ParameterDefinition> parameters,
            CodeFragment body)

            : base(
                  name: name,
                  modifier: modifier,
                  attributeGroups: attributeGroups)
        {
            ReturnType = returnType;
            Body = body;
            Parameters = parameters;
        }

        public IReadOnlyList<IParameter> Parameters { get; }

        public ITypeUsage ReturnType { get; protected private set; }

        public ICodeFragment Body { get; }
    }
}
