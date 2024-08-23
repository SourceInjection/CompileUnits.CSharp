using System.Collections.Generic;
using CompileUnits.CSharp.Implementation.Attributes;
using CompileUnits.CSharp.Implementation.Parameters;
using System.Linq;

namespace CompileUnits.CSharp.Implementation.Members
{
    internal abstract class InvokableMemberDefinition : MemberDefinition, IInvokableMember
    {
        private protected InvokableMemberDefinition(
            string name,
            AccessModifier modifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage returnType,
            IReadOnlyList<ParameterDefinition> parameters,
            Body body)

            : base(
                  name: name,
                  modifier: modifier,
                  attributeGroups: attributeGroups)
        {
            ReturnType = returnType;
            Body = body;
            Parameters = parameters;
            if (body != null)
                body.ParentNode = this;
            if (returnType != null)
                returnType.ParentNode = this;
            foreach(var parameter in parameters)
                parameter.ParentNode = this;
        }

        public IReadOnlyList<IParameter> Parameters { get; }

        public ITypeUsage ReturnType { get; protected private set; }

        public IBody Body { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            var result = base.ChildNodes();
            if (ReturnType != null)
                result = result.Append(ReturnType);
            result = result.Concat(Parameters);
            if (Body != null)
                result = result.Append(Body);
            return result;
        }
    }
}
