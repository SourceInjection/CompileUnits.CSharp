using System;
using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Implementation.Attributes;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Parameters
{
    internal class ParameterDefinition : IParameter
    {
        internal ParameterDefinition(
            TypeUsage type, 
            string name, 
            ParameterModifier modifier, 
            IReadOnlyList<AttributeGroup> attributes, 
            bool isParamsArray = false, 
            CodeFragment defaultValue = null)
        {
            Type = type;
            Name = name;
            IsParamsArray = isParamsArray;
            DefaultValue = defaultValue;
            AttributeGroups = attributes;
            Modifier = modifier;
            if (defaultValue != null)
                defaultValue.ParentNode = this;
            foreach (var ag in attributes)
                ag.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public ITypeUsage Type { get; }

        public string Name { get; }

        public ParameterModifier Modifier { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public ICodeFragment DefaultValue { get; }

        public bool IsParamsArray { get; }

        public IEnumerable<ITreeNode> ChildNodes()
        {
            return ((IReadOnlyList<ITreeNode>)AttributeGroups)
                .Append(Type)
                .Append(DefaultValue);
        }

        public static ParameterDefinition FromContext(Arg_declarationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new ParameterDefinition(
                    type: TypeUsage.FromContext(context.type_()),
                    name: context.identifier().GetText(),
                    modifier: ParameterModifier.None,
                    attributes: Array.Empty<AttributeGroup>(),
                    isParamsArray: false,
                    defaultValue: null);
        }
    }
}
