using Antlr4.Runtime.Tree;
using CodeUnits.CSharp.Implementation.Common;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation
{
    internal class TypeUsage : ITypeUsage
    {
        private TypeUsage(IReadOnlyList<TerminalSymbol> symbols, string formatedText)
        {
            Symbols = symbols;
            foreach (var symbol in symbols)
                symbol.ParentNode = this;
            FormatedText = formatedText;
        }

        public ITreeNode ParentNode { get; internal set; }

        public IReadOnlyList<ITerminalSymbol> Symbols { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Symbols;

        public string FormatedText { get; }

        internal static TypeUsage Void { get; } = CreateVoidType();

        public override string ToString()
        {
            return FormatedText;
        }

        private static TypeUsage CreateVoidType()
        {
            const string voidType = "void";
            var voidSymbol = new TerminalSymbol(TerminalSymbolKind.Void, voidType);
            return FromSymbol(voidSymbol);
        }

        private static TypeUsage FromTree(ITree tree)
        {
            if(tree == null)
                return null;
            return FromSymbols(TerminalSymbols.FromNode(tree));
        }

        internal static TypeUsage FromSymbol(TerminalSymbol symbol)
        {
            if(symbol == null) 
                return null;
            return FromSymbols(new TerminalSymbol[] { symbol });
        }

        internal static TypeUsage FromSymbols(IReadOnlyList<TerminalSymbol> symbols) => new TypeUsage(symbols, Text.TypeUsage(symbols));

        internal static TypeUsage FromContext(Namespace_or_type_nameContext context) => FromTree(context);

        internal static TypeUsage FromContext(Array_typeContext context) => FromTree(context);

        internal static TypeUsage FromContext(Type_Context context) => FromTree(context);

        internal static TypeUsage FromContext(Class_typeContext context) => FromTree(context);

        internal static TypeUsage FromContext(Enum_base_typeContext context) => FromTree(context);
    }
}
