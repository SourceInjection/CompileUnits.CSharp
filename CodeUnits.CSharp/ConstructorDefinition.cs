using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class ConstructorDefinition : InvokableMemberDefinition
    {
        internal ConstructorDefinition(
            AccessModifier accessModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups, 
            IReadOnlyList<ParameterDefinition> parameters, 
            Code body) 
            
            : base(string.Empty, accessModifier, attributeGroups, null, parameters, body)
        { }

        public override TypeDefinition ContainingType 
        { 
            get => base.ContainingType; 
            internal set
            {
                base.ContainingType = value;
                if (value != null)
                    ReturnType = new TypeUsage(new TerminalSymbol(TerminalSymbolKind.Identifier, value.Name));
            } 
        }

        public override MemberKind MemberKind { get; } = MemberKind.Constructor;
    }
}
