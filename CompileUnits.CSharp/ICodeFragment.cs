using Antlr4.Runtime;
using CompileUnits.CSharp.Generated;
using CompileUnits.CSharp.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompileUnits.CSharp
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

        /// <summary>
        /// The kind of the code fragment.
        /// </summary>
        FragmentKind FragmentKind { get; }
    }

    public static class ICodeFragmentExtensions
    {
        /// <summary>
        /// Checks if the given fragment is of the desired kind.
        /// </summary>
        /// <param name="fragment">The fragment to be checked.</param>
        /// <param name="kind">The desired fragment kind.</param>
        /// <returns><see langword="true"/>if the code fragment is of the desired kind else <see langword="false"/></returns>
        public static bool IsKind(this ICodeFragment fragment, FragmentKind kind) 
            => fragment.FragmentKind == kind;

        /// <summary>
        /// Computes the token index of the given code by tokenize the code and comparing the tokens.
        /// Use #i for identifier placeholders.
        /// </summary>
        /// <param name="fragment">The fragment to be checked.</param>
        /// <param name="code">The code which is tokenized and then searched.</param>
        /// <param name="startIndex">The start index from where the search begins.</param>
        /// <returns>-1 if the fragment does not contain the searched code and the token index if it contains the code.</returns>
        public static int IndexOf(this ICodeFragment fragment, string code, int startIndex = 0)
        {
            if (fragment.Symbols.Count == 0)
                return -1;

            TerminalSymbol[] tokens;

            try { tokens = GetTokens(fragment, code).ToArray(); }
            catch { return -1; }

            return IndexOf(fragment, tokens, startIndex);
        }

        /// <summary>
        /// Checks if the fragment contains the given code.
        /// Use #i for identifier placeholders.
        /// </summary>
        /// <param name="fragment">The fragment which is checked.</param>
        /// <param name="code">The code which is tokenized and then searched.</param>
        /// <returns><see langword="true"/> if the fragment contains the code else <see langword="false"/></returns>
        public static bool Contains(this ICodeFragment fragment, string code)
        {
            return fragment.IndexOf(code) >= 0;
        }

        /// <summary>
        /// Checks if the fragment equals a given code by tokenize the code and comparing the symbols.
        /// Use #i for identifier placeholders.
        /// </summary>
        /// <param name="fragment">The fragment which is checked.</param>
        /// <param name="code">The code which is tokenized and then compared.</param>
        /// <returns><see cref="true"/> if the fragment equals the code else <see cref="false"/></returns>
        public static bool IsEquivalentTo(this ICodeFragment fragment, string code)
        {
            TerminalSymbol[] tokens;

            try { tokens = GetTokens(fragment, code).ToArray(); }
            catch { return false; }

            if(fragment.Symbols.Count != tokens.Length) 
                return false;

            return IndexOf(fragment, tokens) == 0;
        }

        private static IEnumerable<TerminalSymbol> GetTokens(ICodeFragment fragment, string code)
        {
            var tokens = new CSharpLexer(new AntlrInputStream(code))
                .GetAllTokens().Select(t => GetToken(fragment, t)).ToArray();

            int i = 0;
            while(i < tokens.Length - 1)
            {
                if (IsIdentifierPlaceholderPair(tokens[i], tokens[i + 1]))
                {
                    yield return new TerminalSymbol(TerminalSymbolKind.Identifier, "#i");
                    i++;
                }
                else yield return tokens[i];
                i++;
            }
            if (i < tokens.Length)
                yield return tokens[i];
        }

        private static int IndexOf(ICodeFragment fragment, TerminalSymbol[] tokens, int startIndex = 0)
        {
            if (tokens.Length == 0 || tokens.Length > fragment.Symbols.Count - startIndex)
                return -1;

            for (int i = startIndex; i < fragment.Symbols.Count; i++)
            {
                int j = 0;
                while (j < tokens.Length && i + j < fragment.Symbols.Count && SymbolEquals(fragment.Symbols[i + j], tokens[j]))
                    j++;

                if (j == tokens.Length)
                    return i;
            }
            return -1;
        }

        private static bool IsIdentifierPlaceholderPair(TerminalSymbol sy, TerminalSymbol next)
        {
            return sy.IsKind(TerminalSymbolKind.Sharp)
                && next.IsKind(TerminalSymbolKind.Identifier)
                && next.Value == "i";
        }

        private static TerminalSymbol GetToken(ICodeFragment fragment, IToken t)
        {
            var result = TerminalSymbol.FromToken(t);
            result.ParentNode = fragment;
            return result;
        }

        private static bool SymbolEquals(ITerminalSymbol a, ITerminalSymbol b)
        {
            return a.Kind == b.Kind && a.Value == b.Value
                || a.IsKind(TerminalSymbolKind.Identifier) && b.IsKind(TerminalSymbolKind.Identifier)  && (a.Value == "#i" || b.Value == "#i");
        }
    }
}
