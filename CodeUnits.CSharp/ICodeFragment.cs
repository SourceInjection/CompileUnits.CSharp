using Antlr4.Runtime;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents code fragments like method bodies, expressions, arrow functions etc..
    /// </summary>
    public interface ICodeFragment : ITreeNode
    {
        /// <summary>
        /// Lists the terminal symbols of the code fragment.
        /// </summary>
        IReadOnlyList<ITerminalSymbol> Symbols { get; }
    }

    public static class ICodeFragmentEstensions
    {
    /// <summary>
    /// Computes the token index of the given code by tokenize the code and comparing the tokens.
    /// </summary>
    /// <param name="fragment">The fragment to be checked.</param>
    /// <param name="code">The code which is tokenized and then searched.</param>
    /// <param name="startIndex">The start index from where the search begins.</param>
    /// <returns>-1 if the fragment does not contain the searched code and the token index if it contains the code.</returns>
        public static int IndexOf(this ICodeFragment fragment, string code, int startIndex = 0)
        {
            if (fragment.Symbols.Count == 0)
                return -1;

            CSharpLexer lexer;
            TerminalSymbol[] tokens;

            try
            {
                lexer = new CSharpLexer(new AntlrInputStream(code));
                tokens = lexer.GetAllTokens().Select(t => TerminalSymbol.FromToken(t)).ToArray();
            }
            catch { return -1; }

            if (tokens.Length == 0 || tokens.Length > fragment.Symbols.Count - startIndex)
                return -1;

            for (int i = startIndex; i < fragment.Symbols.Count; i++)
            {
                int j = 0;
                while (j < tokens.Length && i + j < fragment.Symbols.Count && fragment.Symbols[i + j].Equals(tokens[j]))
                    j++;

                if (j == tokens.Length)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Checks if the fragment contains the given code.
        /// </summary>
        /// <param name="fragment">The fragment which is checked.</param>
        /// <param name="code">The code which is tokenized and then searched.</param>
        /// <returns><see langword="true"/> if the fragment contains the code else <see langword="false"/></returns>
        public static bool Contains(this ICodeFragment fragment, string code)
        {
            return fragment.IndexOf(code) >= 0;
        }
    }
}
