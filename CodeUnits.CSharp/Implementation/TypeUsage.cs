using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation
{
    public class TypeUsage : ITypeUsage
    {
        internal TypeUsage(TerminalSymbol symbol)
        {
            Symbols = new TerminalSymbol[] { symbol };
            FormatedText = symbol.Value;
        }

        private TypeUsage(ITree context)
        {
            var symbols = Common.Symbols.FromNode(context);
            Symbols = symbols;
            FormatedText = Common.Text.TypeUsage(symbols);
        }

        internal TypeUsage(Type_Context context)
            : this((ITree)context)
        { }

        internal TypeUsage(Array_typeContext context)
            : this((ITree)context)
        { }

        internal TypeUsage(Class_typeContext context)
            : this((ITree)context)
        { }

        internal TypeUsage(Namespace_or_type_nameContext context)
            : this((ITree)context)
        { }

        internal TypeUsage(IReadOnlyList<TerminalSymbol> symbols)
        {
            Symbols = symbols;
            FormatedText = Common.Text.TypeUsage(symbols);
        }

        private TypeUsage()
        {
            const string voidType = "void";
            var voidSymbol = new TerminalSymbol(TerminalSymbolKind.Void, voidType);
            Symbols = new TerminalSymbol[] { voidSymbol };
            FormatedText = voidType;
        }

        public IReadOnlyList<ITerminalSymbol> Symbols { get; }

        public string FormatedText { get; }

        public override string ToString()
        {
            return FormatedText;
        }

        internal static TypeUsage Void { get; } = new TypeUsage();
    }
}
