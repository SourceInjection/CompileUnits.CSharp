using Antlr4.Runtime;
using CompileUnits.CSharp.Exceptions;
using CompileUnits.CSharp.Generated;
using CompileUnits.CSharp.Implementation.Usings;
using CompileUnits.CSharp.Implementation;
using CompileUnits.CSharp.Listeners;
using CompileUnits.CSharp.Visitors;
using System;
using System.Collections.Generic;
using System.IO;

namespace CompileUnits.CSharp
{
    /// <summary>
    /// The main entry point for this library.<br/>
    /// A factory to get a code unit from a <see cref="Stream"/> or a <see langword="string"/>.
    /// </summary>
    public static class CompileUnit
    {
        /// <summary>
        /// Serializes C# code.
        /// </summary>
        /// <param name="stream">The code to parse.</param>
        /// <returns>A <see cref="ICompileUnit"/> which represents serialized C# code.</returns>
        /// <exception cref="MalformedCodeException"/>
        /// <exception cref="IOException"/>
        public static ICompileUnit FromStream(Stream stream)
        {
            return FromStream(new AntlrInputStream(stream));
        }

        /// <summary>
        /// Serializes C# code.
        /// </summary>
        /// <param name="text">The code to parse.</param>
        /// <returns>A <see cref="ICompileUnit"/> which represents serialized C# code.</returns>
        /// <exception cref="MalformedCodeException"/>
        public static ICompileUnit FromString(string text)
        {
            return FromStream(new AntlrInputStream(text));
        }

        private static ICompileUnit FromStream(ICharStream stream)
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

                return new Implementation.CompileUnit(
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
