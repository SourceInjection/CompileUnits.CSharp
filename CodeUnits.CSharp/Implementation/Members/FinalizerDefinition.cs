using System;
using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Parameters;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class FinalizerDefinition : InvokableMemberDefinition, IFinalizer
    {
        private FinalizerDefinition(IReadOnlyList<AttributeGroup> attributeGroups, Body body)
            : base(
                  "~",
                  AccessModifier.None,
                  attributeGroups,
                  TypeUsage.Void,
                  Array.Empty<ParameterDefinition>(),
                  body)
        { }

        public override MemberKind MemberKind { get; } = MemberKind.Destructor;

        internal static FinalizerDefinition FromContext(Destructor_definitionContext context, List<AttributeGroup> attributeGroups)
        {
            return new FinalizerDefinition(attributeGroups, Implementation.Body.FromContext(context.body()));
        }
    }
}
