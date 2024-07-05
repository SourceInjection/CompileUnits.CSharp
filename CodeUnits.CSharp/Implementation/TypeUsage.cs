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
            FormatedText = formatedText;
        }

        public IReadOnlyList<ITerminalSymbol> Symbols { get; }

        public string FormatedText { get; }

        public override string ToString()
        {
            return FormatedText;
        }

        internal static TypeUsage Void { get; } = CreateVoidType();

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
            return FromSymbols(Common.Symbols.FromNode(tree));
        }

        internal static TypeUsage FromSymbol(TerminalSymbol symbol)
        {
            if(symbol == null) 
                return null;
            return FromSymbols(new TerminalSymbol[] { symbol });
        }

        internal static TypeUsage FromSymbols(IReadOnlyList<TerminalSymbol> symbols) 
            => new TypeUsage(symbols, Text.TypeUsage(symbols));

        internal static TypeUsage FromContext(Namespace_or_type_nameContext context) => FromTree(context);

        internal static TypeUsage FromContext(Array_typeContext context) => FromTree(context);

        internal static TypeUsage FromContext(Type_Context context) => FromTree(context);

        internal static TypeUsage FromContext(Class_typeContext context) => FromTree(context);
    }
}
