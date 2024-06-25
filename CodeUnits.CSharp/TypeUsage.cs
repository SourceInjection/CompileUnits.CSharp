using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp
{
    public class TypeUsage
    {
        private TypeUsage(ITree context)
        {
            Symbols = Common.Symbols.FromNode(context);
            FormatedText = Common.Text.TypeUsage(Symbols);
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


        private TypeUsage()
        {
            const string voidType = "void";
            var voidSymbol = new TerminalSymbol(TerminalSymbolKind.Void, voidType);
            Symbols = new TerminalSymbol[] { voidSymbol };
            FormatedText = voidType;
        }

        public IReadOnlyList<TerminalSymbol> Symbols { get; }

        public string FormatedText { get; }

        public override string ToString()
        {
            return FormatedText;
        }

        internal static TypeUsage Void { get; } = new TypeUsage();
    }
}
