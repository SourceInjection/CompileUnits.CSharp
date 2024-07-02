using System;
using CodeUnits.CSharp.Implementation.Attributes;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal static class AccessorDefinitions
    {
        public static (AccessorDefinition Getter, AccessorDefinition Setter) FromContext(Indexer_declarationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.throwable_expression() != null)
                return (GetterFromArrowFunction(context.throwable_expression()), null);
            return AccessorsFromAccessorsDeclaration(context.accessor_declarations());
        }

        public static (AccessorDefinition Getter, AccessorDefinition Setter) FromContext(Property_declarationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.throwable_expression() != null)
                return (GetterFromArrowFunction(context.throwable_expression()), null);
            return AccessorsFromAccessorsDeclaration(context.accessor_declarations());
        }

        public static (AccessorDefinition Add, AccessorDefinition Remove) FromContext(Event_accessor_declarationsContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var attributes = AttributeGroups.FromContext(context.attributes());
            if (context.remove_accessor_declaration() != null)
            {
                var add = new AccessorDefinition(
                    name: "add",
                    accessModifier: AccessModifier.None,
                    attributeGroups: attributes,
                    body: CodeFragment.FromContext(context.block()),
                    kind: AccessorKind.Add);

                return (add, RemoveFromAccessorDeclaration(context.remove_accessor_declaration()));
            }
            else
            {
                var remove = new AccessorDefinition(
                    name: "remove",
                    accessModifier: AccessModifier.None,
                    attributeGroups: attributes,
                    body: CodeFragment.FromContext(context.block()),
                    kind: AccessorKind.Remove);

                return (AddFromAccessorDeclaration(context.add_accessor_declaration()), remove);
            }
        }

        private static AccessorDefinition RemoveFromAccessorDeclaration(Remove_accessor_declarationContext context)
        {
            return FromAnyEventAccessor(context.attributes(), context.block(), AccessorKind.Remove);
        }

        private static AccessorDefinition AddFromAccessorDeclaration(Add_accessor_declarationContext context)
        {
            return FromAnyEventAccessor(context.attributes(), context.block(), AccessorKind.Add);
        }

        private static AccessorDefinition FromAnyEventAccessor(AttributesContext attributesContext, BlockContext blockContext, AccessorKind accessorKind)
        {
            var name = accessorKind == AccessorKind.Add
                ? "add"
                : "remove";
            var attributes = AttributeGroups.FromContext(attributesContext);
            var body = CodeFragment.FromContext(blockContext);

            return new AccessorDefinition(
                name: name,
                accessModifier: AccessModifier.None,
                attributeGroups: attributes,
                body: body,
                kind: accessorKind);
        }

        private static AccessorDefinition GetterFromArrowFunction(Throwable_expressionContext context)
        {
            return new AccessorDefinition(
                name: "get",
                accessModifier: AccessModifier.None,
                attributeGroups: Array.Empty<AttributeGroup>(),
                body: CodeFragment.FromContext(context),
                kind: AccessorKind.Getter);
        }

        private static (AccessorDefinition Getter, AccessorDefinition Setter) AccessorsFromAccessorsDeclaration(Accessor_declarationsContext context)
        {
            AccessorDefinition getter;
            AccessorDefinition setter;

            var attributes = AttributeGroups.FromContext(context.attrs);
            var modifier = AccessorDefinition.GetAccessModifier(context.mods);
            var body = CodeFragment.FromContext(context.accessor_body()?.block());

            if (context.GET() != null)
            {
                getter = new AccessorDefinition(
                    name: "get",
                    accessModifier: modifier,
                    attributeGroups: attributes,
                    body: body,
                    kind: AccessorKind.Getter);
                setter = AccessorDefinition.FromContext(context.set_accessor_declaration());
            }
            else
            {
                setter = new AccessorDefinition(
                    name: "set",
                    accessModifier: modifier,
                    attributeGroups: attributes,
                    body: body,
                    kind: AccessorKind.Setter);
                getter = AccessorDefinition.FromContext(context.get_accessor_declaration());
            }
            return (getter, setter);
        }
    }
}
