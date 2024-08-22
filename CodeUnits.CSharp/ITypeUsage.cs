using Antlr4.Runtime;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the usage of a type.
    /// </summary>
    public interface ITypeUsage : ITreeNode
    {
        /// <summary>
        /// Lists all terminal symbol within the type usage.
        /// </summary>
        IReadOnlyList<ITerminalSymbol> Symbols { get; }

        /// <summary>
        /// Represents the type usage as formated <see langword="string"/>.
        /// </summary>
        string FormatedText { get; }
    }

    public static class ITypeUsageExtensions
    {
        /// <summary>
        /// Checks if the fragment equals a given code by tokenize the code and comparing the symbols.
        /// </summary>
        /// <param name="fragment">The fragment which is checked.</param>
        /// <param name="code">The code which is tokenized and then compared.</param>
        /// <returns><see cref="true"/> if the fragment equals the code else <see cref="false"/></returns>
        public static bool IsEquivalentTo(this ITypeUsage fragment, string code)
        {
            TerminalSymbol[] tokens;

            try { tokens = GetTokens(code); }
            catch { return false; }

            return tokens.SequenceEqual(fragment.Symbols);
        }

        private static TerminalSymbol[] GetTokens(string code)
        {
            return new CSharpLexer(new AntlrInputStream(code))
                .GetAllTokens().Select(t => TerminalSymbol.FromToken(t)).ToArray();
        }
    }
}
