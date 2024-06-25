﻿using CodeUnits.CSharp.Generated;
using System;
using System.Collections.Generic;

namespace CodeUnits.CSharp.Common
{
    internal static class Symbol
    {
        public static TerminalSymbolKind KindFromAntlrType(int id)
        {
            if (_symbolKind.TryGetValue(id, out var symbolKind))
                return symbolKind;
            throw new InvalidOperationException($"{nameof(CSharpParser)} does not have a token in its dictionary with id '{id}'.");
        }



        public static bool IsPredefinedType(TerminalSymbolKind symbolKind)
        {
            return IsObject(symbolKind)
                || IsString(symbolKind)
                || IsSimpleType(symbolKind);
        }

        public static bool IsObject(TerminalSymbolKind symbolKind)
        {
            return symbolKind == TerminalSymbolKind.Object;
        }

        public static bool IsString(TerminalSymbolKind symbolKind)
        {
            return symbolKind == TerminalSymbolKind.String;
        }

        public static bool IsSimpleType(TerminalSymbolKind symbolKind)
        {
            return IsBoolean(symbolKind)
                || IsInteger(symbolKind)
                || IsReal(symbolKind);
        }

        public static bool IsInteger(TerminalSymbolKind symbolKind)
        {
            return symbolKind == TerminalSymbolKind.Sbyte
                || symbolKind == TerminalSymbolKind.Byte
                || symbolKind == TerminalSymbolKind.Short
                || symbolKind == TerminalSymbolKind.Ushort
                || symbolKind == TerminalSymbolKind.Int
                || symbolKind == TerminalSymbolKind.Uint
                || symbolKind == TerminalSymbolKind.Long
                || symbolKind == TerminalSymbolKind.Ulong
                || symbolKind == TerminalSymbolKind.Char;
        }

        public static bool IsReal(TerminalSymbolKind symbolKind)
        {
            return symbolKind == TerminalSymbolKind.Float
                || symbolKind == TerminalSymbolKind.Double
                || symbolKind == TerminalSymbolKind.Decimal;
        }

        public static bool IsBoolean(TerminalSymbolKind symbolKind)
        {
            return symbolKind == TerminalSymbolKind.Bool;
        }


        private static readonly Dictionary<int, TerminalSymbolKind> _symbolKind = new Dictionary<int, TerminalSymbolKind>()
        {
            [CSharpParser.IDENTIFIER] = TerminalSymbolKind.Identifier,
            [CSharpParser.REAL_LITERAL] = TerminalSymbolKind.RealLiteral,
            [CSharpParser.BIN_INTEGER_LITERAL] = TerminalSymbolKind.BinaryIntegerLiteral,
            [CSharpParser.HEX_INTEGER_LITERAL] = TerminalSymbolKind.HexIntegerLiteral,
            [CSharpParser.INTEGER_LITERAL] = TerminalSymbolKind.IntegerLiteral,
            [CSharpParser.CHARACTER_LITERAL] = TerminalSymbolKind.CharacterLiteral,
            [CSharpParser.REGULAR_STRING] = TerminalSymbolKind.StringLiteral,
            [CSharpParser.VERBATIUM_STRING] = TerminalSymbolKind.VerbatiumStringLiteral,
            [CSharpParser.INTERPOLATED_REGULAR_STRING_START] = TerminalSymbolKind.InterpolatedStringLiteralStart,
            [CSharpParser.INTERPOLATED_VERBATIUM_STRING_START] = TerminalSymbolKind.InterpolatedVerbatiumStringLiteralStart,
            [CSharpParser.PLUS] = TerminalSymbolKind.PlusOperator,
            [CSharpParser.MINUS] = TerminalSymbolKind.MinusOperator,
            [CSharpParser.STAR] = TerminalSymbolKind.MultiplicationOperator,
            [CSharpParser.DIV] = TerminalSymbolKind.DivisionOperator,
            [CSharpParser.PERCENT] = TerminalSymbolKind.ModuloOperator,
            [CSharpParser.AMP] = TerminalSymbolKind.BitwiseAndOperator,
            [CSharpParser.BITWISE_OR] = TerminalSymbolKind.BitwiseOrOperator,
            [CSharpParser.CARET] = TerminalSymbolKind.XorOperator,
            [CSharpParser.BANG] = TerminalSymbolKind.NotOperator,
            [CSharpParser.ASSIGNMENT] = TerminalSymbolKind.AssignmentOperator,
            [CSharpParser.OP_ADD_ASSIGNMENT] = TerminalSymbolKind.AdditionAssignmentOperator,
            [CSharpParser.OP_SUB_ASSIGNMENT] = TerminalSymbolKind.SubtractionAssignmentOperator,
            [CSharpParser.OP_MULT_ASSIGNMENT] = TerminalSymbolKind.MultiplicationAssignmentOperator,
            [CSharpParser.OP_DIV_ASSIGNMENT] = TerminalSymbolKind.DivisionAssignmentOperator,
            [CSharpParser.OP_MOD_ASSIGNMENT] = TerminalSymbolKind.ModuloAssignmentOperator,
            [CSharpParser.OP_AND_ASSIGNMENT] = TerminalSymbolKind.AndAssignmentOperator,
            [CSharpParser.OP_OR_ASSIGNMENT] = TerminalSymbolKind.OrAssignmentOperator,
            [CSharpParser.OP_XOR_ASSIGNMENT] = TerminalSymbolKind.XorAssignmentOperator,
            [CSharpParser.OP_LEFT_SHIFT] = TerminalSymbolKind.LeftShiftOperator,
            [CSharpParser.OP_LEFT_SHIFT_ASSIGNMENT] = TerminalSymbolKind.LeftShiftAssignmentOperator,
            [CSharpParser.OP_COALESCING_ASSIGNMENT] = TerminalSymbolKind.CoalesceAssignmentOperator,
            [CSharpParser.OP_RANGE] = TerminalSymbolKind.RangeOperator,
            [CSharpParser.OP_RIGHT_SHIFT] = TerminalSymbolKind.RightShiftOperator,
            [CSharpParser.OP_RIGHT_SHIFT_ASSIGNMENT] = TerminalSymbolKind.RightShiftAssignmentOperator,
            [CSharpParser.OP_NE] = TerminalSymbolKind.NotEqualsOperator,
            [CSharpParser.OP_LE] = TerminalSymbolKind.LessEqualsOperator,
            [CSharpParser.OP_GE] = TerminalSymbolKind.GreaterEqualsOperator,
            [CSharpParser.LT] = TerminalSymbolKind.LessThanOperator,
            [CSharpParser.GT] = TerminalSymbolKind.GreaterThanOperator,
            [CSharpParser.OP_EQ] = TerminalSymbolKind.EqualsOperator,
            [CSharpParser.OP_COALESCING] = TerminalSymbolKind.CoalesceOperator,
            [CSharpParser.OP_INC] = TerminalSymbolKind.IncrementOperator,
            [CSharpParser.OP_DEC] = TerminalSymbolKind.DecrementOperator,
            [CSharpParser.OP_AND] = TerminalSymbolKind.AndOperator,
            [CSharpParser.OP_OR] = TerminalSymbolKind.OrOperator,
            [CSharpParser.OP_PTR] = TerminalSymbolKind.PointerDereferenceOperator,
            [CSharpParser.INTERR] = TerminalSymbolKind.NullConditionalOperator,
            [CSharpParser.RIGHT_ARROW] = TerminalSymbolKind.RightArrow,
            [CSharpParser.DOUBLE_COLON] = TerminalSymbolKind.DoubleColon,
            [CSharpParser.OPEN_BRACE] = TerminalSymbolKind.OpenBrace,
            [CSharpParser.CLOSE_BRACE] = TerminalSymbolKind.CloseBrace,
            [CSharpParser.OPEN_BRACKET] = TerminalSymbolKind.OpenBracket,
            [CSharpParser.CLOSE_BRACKET] = TerminalSymbolKind.CloseBracket,
            [CSharpParser.OPEN_PARENS] = TerminalSymbolKind.OpenParenthese,
            [CSharpParser.CLOSE_PARENS] = TerminalSymbolKind.CloseParenthese,
            [CSharpParser.DOT] = TerminalSymbolKind.AccessOperator,
            [CSharpParser.COMMA] = TerminalSymbolKind.Comma,
            [CSharpParser.COLON] = TerminalSymbolKind.Colon,
            [CSharpParser.SEMICOLON] = TerminalSymbolKind.Semicolon,
            [CSharpParser.TILDE] = TerminalSymbolKind.Tilde,
            [CSharpParser.ABSTRACT] = TerminalSymbolKind.Abstract,
            [CSharpParser.ADD] = TerminalSymbolKind.Add,
            [CSharpParser.ALIAS] = TerminalSymbolKind.Alias,
            [CSharpParser.AND] = TerminalSymbolKind.And,
            [CSharpParser.ARGLIST] = TerminalSymbolKind.Arglist,
            [CSharpParser.ASCENDING] = TerminalSymbolKind.Ascending,
            [CSharpParser.ASYNC] = TerminalSymbolKind.Async,
            [CSharpParser.AS] = TerminalSymbolKind.As,
            [CSharpParser.AWAIT] = TerminalSymbolKind.Await,
            [CSharpParser.BASE] = TerminalSymbolKind.Base,
            [CSharpParser.BOOL] = TerminalSymbolKind.Bool,
            [CSharpParser.BREAK] = TerminalSymbolKind.Break,
            [CSharpParser.BYTE] = TerminalSymbolKind.Byte,
            [CSharpParser.BY] = TerminalSymbolKind.By,
            [CSharpParser.CASE] = TerminalSymbolKind.Case,
            [CSharpParser.CATCH] = TerminalSymbolKind.Catch,
            [CSharpParser.CHAR] = TerminalSymbolKind.Char,
            [CSharpParser.CHECKED] = TerminalSymbolKind.Checked,
            [CSharpParser.CLASS] = TerminalSymbolKind.Class,
            [CSharpParser.CONST] = TerminalSymbolKind.Const,
            [CSharpParser.CONTINUE] = TerminalSymbolKind.Continue,
            [CSharpParser.DECIMAL] = TerminalSymbolKind.Decimal,
            [CSharpParser.DEFAULT] = TerminalSymbolKind.Default,
            [CSharpParser.DELEGATE] = TerminalSymbolKind.Delegate,
            [CSharpParser.DESCENDING] = TerminalSymbolKind.Descending,
            [CSharpParser.DOUBLE] = TerminalSymbolKind.Double,
            [CSharpParser.DO] = TerminalSymbolKind.Do,
            [CSharpParser.DYNAMIC] = TerminalSymbolKind.Dynamic,
            [CSharpParser.ELSE] = TerminalSymbolKind.Else,
            [CSharpParser.ENUM] = TerminalSymbolKind.Enum,
            [CSharpParser.EQUALS] = TerminalSymbolKind.Equals,
            [CSharpParser.EVENT] = TerminalSymbolKind.Event,
            [CSharpParser.EXPLICIT] = TerminalSymbolKind.Explicit,
            [CSharpParser.EXTERN] = TerminalSymbolKind.Extern,
            [CSharpParser.FALSE] = TerminalSymbolKind.False,
            [CSharpParser.FINALLY] = TerminalSymbolKind.Finally,
            [CSharpParser.FIXED] = TerminalSymbolKind.Fixed,
            [CSharpParser.FLOAT] = TerminalSymbolKind.Float,
            [CSharpParser.FOREACH] = TerminalSymbolKind.Foreach,
            [CSharpParser.FOR] = TerminalSymbolKind.For,
            [CSharpParser.FROM] = TerminalSymbolKind.From,
            [CSharpParser.GET] = TerminalSymbolKind.Get,
            [CSharpParser.GOTO] = TerminalSymbolKind.Goto,
            [CSharpParser.GROUP] = TerminalSymbolKind.Group,
            [CSharpParser.IF] = TerminalSymbolKind.If,
            [CSharpParser.IMPLICIT] = TerminalSymbolKind.Implicit,
            [CSharpParser.INTERFACE] = TerminalSymbolKind.Interface,
            [CSharpParser.INTERNAL] = TerminalSymbolKind.Internal,
            [CSharpParser.INTO] = TerminalSymbolKind.Into,
            [CSharpParser.INT] = TerminalSymbolKind.Int,
            [CSharpParser.IN] = TerminalSymbolKind.In,
            [CSharpParser.IS] = TerminalSymbolKind.Is,
            [CSharpParser.JOIN] = TerminalSymbolKind.Join,
            [CSharpParser.LET] = TerminalSymbolKind.Let,
            [CSharpParser.LOCK] = TerminalSymbolKind.Lock,
            [CSharpParser.LONG] = TerminalSymbolKind.Long,
            [CSharpParser.NAMEOF] = TerminalSymbolKind.Nameof,
            [CSharpParser.NAMESPACE] = TerminalSymbolKind.Namespace,
            [CSharpParser.NEW] = TerminalSymbolKind.New,
            [CSharpParser.NOTNULL] = TerminalSymbolKind.Notnull,
            [CSharpParser.NOT] = TerminalSymbolKind.Not,
            [CSharpParser.NULL_] = TerminalSymbolKind.Null,
            [CSharpParser.OBJECT] = TerminalSymbolKind.Object,
            [CSharpParser.ON] = TerminalSymbolKind.On,
            [CSharpParser.OPERATOR] = TerminalSymbolKind.Operator,
            [CSharpParser.ORDERBY] = TerminalSymbolKind.Orderby,
            [CSharpParser.OR] = TerminalSymbolKind.Or,
            [CSharpParser.OUT] = TerminalSymbolKind.Out,
            [CSharpParser.OVERRIDE] = TerminalSymbolKind.Override,
            [CSharpParser.PARAMS] = TerminalSymbolKind.Params,
            [CSharpParser.PARTIAL] = TerminalSymbolKind.Partial,
            [CSharpParser.PRIVATE] = TerminalSymbolKind.Private,
            [CSharpParser.PROTECTED] = TerminalSymbolKind.Protected,
            [CSharpParser.PUBLIC] = TerminalSymbolKind.Public,
            [CSharpParser.READONLY] = TerminalSymbolKind.Readonly,
            [CSharpParser.RECORD] = TerminalSymbolKind.Record,
            [CSharpParser.REF] = TerminalSymbolKind.Ref,
            [CSharpParser.REMOVE] = TerminalSymbolKind.Remove,
            [CSharpParser.RETURN] = TerminalSymbolKind.Return,
            [CSharpParser.SBYTE] = TerminalSymbolKind.Sbyte,
            [CSharpParser.SEALED] = TerminalSymbolKind.Sealed,
            [CSharpParser.SELECT] = TerminalSymbolKind.Select,
            [CSharpParser.SET] = TerminalSymbolKind.Set,
            [CSharpParser.SHORT] = TerminalSymbolKind.Short,
            [CSharpParser.SIZEOF] = TerminalSymbolKind.Sizeof,
            [CSharpParser.STACKALLOC] = TerminalSymbolKind.Stackalloc,
            [CSharpParser.STATIC] = TerminalSymbolKind.Static,
            [CSharpParser.STRING] = TerminalSymbolKind.String,
            [CSharpParser.STRUCT] = TerminalSymbolKind.Struct,
            [CSharpParser.SWITCH] = TerminalSymbolKind.Switch,
            [CSharpParser.THIS] = TerminalSymbolKind.This,
            [CSharpParser.THROW] = TerminalSymbolKind.Throw,
            [CSharpParser.TRUE] = TerminalSymbolKind.True,
            [CSharpParser.TRY] = TerminalSymbolKind.Try,
            [CSharpParser.TYPEOF] = TerminalSymbolKind.Typeof,
            [CSharpParser.UINT] = TerminalSymbolKind.Uint,
            [CSharpParser.ULONG] = TerminalSymbolKind.Ulong,
            [CSharpParser.UNCHECKED] = TerminalSymbolKind.Unchecked,
            [CSharpParser.UNMANAGED] = TerminalSymbolKind.Unmanaged,
            [CSharpParser.UNSAFE] = TerminalSymbolKind.Unsafe,
            [CSharpParser.USHORT] = TerminalSymbolKind.Ushort,
            [CSharpParser.USING] = TerminalSymbolKind.Using,
            [CSharpParser.VAR] = TerminalSymbolKind.Var,
            [CSharpParser.VIRTUAL] = TerminalSymbolKind.Virtual,
            [CSharpParser.VOID] = TerminalSymbolKind.Void,
            [CSharpParser.VOLATILE] = TerminalSymbolKind.Volatile,
            [CSharpParser.WHEN] = TerminalSymbolKind.When,
            [CSharpParser.WHERE] = TerminalSymbolKind.Where,
            [CSharpParser.WHILE] = TerminalSymbolKind.While,
            [CSharpParser.YIELD] = TerminalSymbolKind.Yield,
            [CSharpParser.LITERAL_ACCESS] = TerminalSymbolKind.LiteralAccess,
            [CSharpParser.BYTE_ORDER_MARK] = TerminalSymbolKind.ByteOrderMark,
            [CSharpParser.DOUBLE_CURLY_INSIDE] = TerminalSymbolKind.DoubleCurlyOpenInside,
            [CSharpParser.DOUBLE_CURLY_CLOSE_INSIDE] = TerminalSymbolKind.DoubleCurlyCloseInside,
            [CSharpParser.OPEN_BRACE_INSIDE] = TerminalSymbolKind.OpenBraceInside,
            [CSharpParser.CLOSE_BRACE_INSIDE] = TerminalSymbolKind.CloseBraceInside,
            [CSharpParser.REGULAR_CHAR_INSIDE] = TerminalSymbolKind.RegularCharInside,
            [CSharpParser.VERBATIUM_DOUBLE_QUOTE_INSIDE] = TerminalSymbolKind.VerbatiumDoubleQuoteInside,
            [CSharpParser.DOUBLE_QUOTE_INSIDE] = TerminalSymbolKind.DoubleQuoteInside,
            [CSharpParser.REGULAR_STRING_INSIDE] = TerminalSymbolKind.RegularStringInside,
            [CSharpParser.VERBATIUM_INSIDE_STRING] = TerminalSymbolKind.VerbatiumStringInside,
            [CSharpParser.FORMAT_STRING] = TerminalSymbolKind.FormatStringInside,
        };
    }
}
