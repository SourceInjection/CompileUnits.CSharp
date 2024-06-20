using Antlr4.Runtime;

namespace CodeUnits.CSharp
{
    public class TerminalSymbol
    {
        internal TerminalSymbol(IToken token)
        {

        }

        public string Text { get; }

        public TerminalSymbolKind Kind { get; }

        public int Line { get; }

        public int Column { get; }

        public bool IsKeyword { get; }

        public bool IsLiteral { get; }

        public bool IsOperator { get; }

        public bool IsIdentifier { get; }

        public bool IsKind(TerminalSymbolKind kind) => Kind == kind;
    }


    public enum TerminalSymbolKind
    {
        Abstract,
        Add,
        Alias,
        And,
        Arglist,
        As,
        Ascending,
        Async,
        Await,
        Base,
        Bool,
        Break,
        By,
        Byte,
        Case,
        Catch,
        Char,
        Checked,
        Class,
        Const,
        Continue,
        Decimal,
        Default,
        Delegate,
        Descending,
        Do,
        Double,
        Dynamic,
        Else,
        Enum,
        Equals,
        Event,
        Explicit,
        Extern,
        False,
        Finally,
        Fixed,
        Float,
        For,
        Foreach,
        From,
        Get,
        Goto,
        Group,
        If,
        Implicit,
        In,
        Int,
        Interface,
        Internal,
        Into,
        Is,
        Join,
        Let,
        Lock,
        Long,
        Nameof,
        Namespace,
        New,
        Not,
        Notnull,
        Object,
        On,
        Operator,
        Orderby,
        Or,
        Out,
        Override,
        Params,
        Partial,
        Private,
        Protected,
        Public,
        Readonly,
        Record,
        Ref,
        Remove,
        Return,
        Sbyte,
        Sealed,
        Select,
        Set,
        Short,
        Sizeof,
        Stackalloc,
        Static,
        String,
        Struct,
        Switch,
        This,
        Throw,
        True,
        Try,
        Typeof,
        Uint,
        Ulong,
        Unchecked,
        Unmanaged,
        Unsafe,
        Ushort,
        Using,
        Var,
        Virtual,
        Void,
        Volatile,
        When,
        Where,
        While,
        Yield,

        Identifier,
        LiteralAccess,
        IntegerLiteral,
        HexIntegerLiteral,
        BinIntegerLiteral,
        RealLiteral,
        CharacterLiteral,
        RegularString,
        VerbatiumString,
        InterpolatedRegularString,
        InterpolatedVerbatiumString,

        OpenBrace,
        CloseBrace,
        OpenBracket,
        CloseBracket,
        OpenParens,
        CloseParens,
        Dot,
        Comma,
        Colon,
        SemiColon,
        Plus,
        Minus,
        Asterisk,
        Div,
        Percent,
        Amp,
        BitwhiseOr,
        Circumflex,
        Bang,
        Tilde,
        Assignment,
        LT,
        GT,
        Questionmark,
        DoubleColon,
        Coalesce,
        Inc,
        Dec,
        AndOperator,
        OrOperator,
        PointerDereference,
        EQ,
        NE,
        LE,
        GE,
        AddAssign,
        SubAssign,
        MultAssign,
        DivAssign,
        ModAssign,
        AndAssign,
        OrAssign,
        XorAssign,
        LeftShift,
        LeftShiftAssign,

        // TODO

    }


}
