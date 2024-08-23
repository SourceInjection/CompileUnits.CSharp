using Antlr4.Runtime;
using System.Collections.Generic;

namespace CompileUnits.CSharp.Implementation
{
    internal abstract class CodeFragment : ICodeFragment
    {
        protected CodeFragment(IReadOnlyList<TerminalSymbol> symbols, FragmentKind fragmentKind)
        {
            Symbols = symbols;
            foreach (var symbol in symbols)
                symbol.ParentNode = this;
            FragmentKind = fragmentKind;
        }

        public ITreeNode ParentNode { get; internal set; }

        public IReadOnlyList<ITerminalSymbol> Symbols { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Symbols;

        public FragmentKind FragmentKind { get; }
    }
}
