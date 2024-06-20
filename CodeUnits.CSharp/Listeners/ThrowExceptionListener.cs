using Antlr4.Runtime.Misc;
using Antlr4.Runtime;
using CodeUnits.CSharp.Exceptions;

namespace CodeUnits.CSharp.Listeners
{
    internal class ThrowExceptionListener : IAntlrErrorListener<IToken>
    {
        public void SyntaxError(
            [NotNull] IRecognizer recognizer,
            [Nullable] IToken offendingSymbol,
            int line,
            int charPositionInLine,
            [NotNull] string msg,
            [Nullable] RecognitionException e)
        {
            throw new MalformedCodeException($"Syntax error at line {line} column {charPositionInLine}: {msg}", e);
        }
    }
}
