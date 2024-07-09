using Antlr4.Runtime;
using CodeUnits.CSharp.Exceptions;
using CodeUnits.CSharp.Generated;
using CodeUnits.CSharp.Implementation.Usings;
using CodeUnits.CSharp.Implementation;
using CodeUnits.CSharp.Listeners;
using CodeUnits.CSharp.Visitors;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// The main entry point for this library.<br/>
    /// A factory to get a code unit from a <see cref="Stream"/> or a <see langword="string"/>.
    /// </summary>
    public static class CodeUnit
    {
        /// <summary>
        /// Serializes C# code.
        /// </summary>
        /// <param name="stream">The code to parse.</param>
        /// <returns>A <see cref="ICodeUnit"/> which represents serialized C# code.</returns>
        /// <exception cref="MalformedCodeException"/>
        /// <exception cref="IOException"/>
        public static ICodeUnit FromStream(Stream stream)
        {
            return FromStream(new AntlrInputStream(stream));
        }

        /// <summary>
        /// Serializes C# code.
        /// </summary>
        /// <param name="text">The code to parse.</param>
        /// <returns>A <see cref="ICodeUnit"/> which represents serialized C# code.</returns>
        /// <exception cref="MalformedCodeException"/>
        public static ICodeUnit FromString(string text)
        {
            return FromStream(new AntlrInputStream(text));
        }

        private static ICodeUnit FromStream(ICharStream stream)
        {
            try
            {
                var lexer = new CSharpLexer(stream);
                var parser = new CSharpParser(new CommonTokenStream(lexer));

                var listener = new ThrowExceptionListener();
                parser.AddErrorListener(listener);

                var visitor = new NamespaceVisitor();
                var ns = visitor.VisitCompilation_unit(parser.compilation_unit())
                    ?? throw new InvalidOperationException("something went wrong during parsing");

                return new Implementation.CodeUnit(
                    directives: (IReadOnlyList<UsingDirectiveDefinition>)ns.UsingDirectives,
                    members: ns.Members,
                    externAliases: (IReadOnlyList<ExternAliasDefinition>)ns.ExternAliases);
            }
            catch (MalformedCodeException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new MalformedCodeException("The imput code is malformed and can not be parsed.", e);
            }
        }
    }
}
