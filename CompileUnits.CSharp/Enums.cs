namespace CompileUnits.CSharp
{
    public enum FragmentKind { Expression, Body }

    public enum ConstructorInitializerKind { Base, This }

    public enum ConversionKind { Implicit, Explicit }

    public enum Variance 
    { 
        None, 
        /// <summary>Covariant</summary>
        In,
        /// <summary>Contravariant</summary>
        Out
    }

    public enum AccessorKind { Getter, Setter, Add, Remove, }

    public enum InheritanceModifier { None, Sealed, Virtual, Abstract, }

    public enum ParameterModifier { None, Ref, In, Out, RefThis, InThis, This, }

    public enum UsingDirectiveKind { Namespace, Static, Alias }

    public enum ConstraintKind
    {
        Constructor,
        OfType,
        Class,
        ClassNullable,
        Struct,
        Unmanaged,
        NotNull,
        Default,
    }

    public enum AccessModifier
    {
        None,
        Private,
        PrivateProtected,
        Internal,
        Protected,
        ProtectedInternal,
        Public
    }

    public enum NamespaceMemberKind
    {
        Type,
        Namespace,
    }

    public enum MemberKind
    {
        Type,
        Property,
        Field,
        Method,
        Destructor,
        Constructor,
        Operator,
        ConversionOperator,
        Indexer,
        Event,
        Constant,
    }

    public enum TypeKind
    {
        Enum,
        Class,
        Struct,
        Interface,
        Delegate,
    }

    public enum TerminalSymbolKind
    {
        /// <summary>Symbol: '#'</summary>
        Sharp,
        /// <summary>Identifier symbols</summary>
        Identifier,

        /// <summary>Real literals e.g.: 0.08, 0.f</summary>
        RealLiteral,
        /// <summary>Integer literals e.g.: 0b8AF</summary>
        BinaryIntegerLiteral,
        /// <summary>Integer literals e.g.: 0x8AF</summary>
        HexIntegerLiteral,
        /// <summary>Integer literals e.g.: 32767</summary>
        IntegerLiteral,
        /// <summary>Char literals e.g.: 'a', '\t', '\\', '1'</summary>
        CharacterLiteral,
        /// <summary>String literal e.g.: "my string value"</summary>
        StringLiteral,
        /// <summary>Verbatium string literal e.g.: @"my string value"</summary>
        VerbatiumStringLiteral,
        /// <summary>Start of string interpolation: $"</summary>
        InterpolatedStringLiteralStart,
        /// <summary>Start of verbatium string interpolation: $@"</summary>
        InterpolatedVerbatiumStringLiteralStart,

        /// <summary>Symbol: +</summary>
        PlusOperator,
        /// <summary>Symbol: -</summary>
        MinusOperator,
        /// <summary>Symbol: *</summary>
        MultiplicationOperator,
        /// <summary>Symbol: /</summary>
        DivisionOperator,
        /// <summary>Symbol: %</summary>
        ModuloOperator,
        /// <summary>Symbol: &amp;</summary>
        BitwiseAndOperator,
        /// <summary>Symbol: |</summary>
        BitwiseOrOperator,
        /// <summary>Symbol: ^</summary>
        XorOperator,
        /// <summary>Symbol: !</summary>
        NotOperator,
        /// <summary>Symbol: =</summary>
        AssignmentOperator,
        /// <summary>Symbol: +=</summary>
        AdditionAssignmentOperator,
        /// <summary>Symbol: -=</summary>
        SubtractionAssignmentOperator,
        /// <summary>Symbol: *=</summary>
        MultiplicationAssignmentOperator,
        /// <summary>Symbol: /=</summary>
        DivisionAssignmentOperator,
        /// <summary>Symbol: %=</summary>
        ModuloAssignmentOperator,
        /// <summary>Symbol: &amp;=</summary>
        AndAssignmentOperator,
        /// <summary>Symbol: |=</summary>
        OrAssignmentOperator,
        /// <summary>Symbol: ^=</summary>
        XorAssignmentOperator,
        /// <summary>Symbol: &lt;&lt;</summary>
        LeftShiftOperator,
        /// <summary>Symbol: &lt;&lt;=</summary>
        LeftShiftAssignmentOperator,
        /// <summary>Symbol: ??=</summary>
        CoalesceAssignmentOperator,
        /// <summary>Symbol: ..</summary>
        RangeOperator,
        /// <summary>Symbol: &gt;&gt;=</summary>
        RightShiftAssignmentOperator,
        /// <summary>Symbol: !=</summary>
        NotEqualsOperator,
        /// <summary>Symbol: %lt;=</summary>
        LessEqualsOperator,
        /// <summary>Symbol: &gt;=</summary>
        GreaterEqualsOperator,
        /// <summary>Symbol: &lt;</summary>
        LessThanOperator,
        /// <summary>Symbol: &gt;</summary>
        GreaterThanOperator,
        /// <summary>Symbol: ==;</summary>
        EqualsOperator,
        /// <summary>Symbol: ??</summary>
        CoalesceOperator,
        /// <summary>Symbol: ++</summary>
        IncrementOperator,
        /// <summary>Symbol: --</summary>
        DecrementOperator,
        /// <summary>Symbol: &amp;&amp;</summary>
        AndOperator,
        /// <summary>Symbol: ||</summary>
        OrOperator,
        /// <summary>Symbol: -></summary>
        PointerDereferenceOperator,
        /// <summary>Symbol: ?</summary>
        NullConditionalOperator,

        /// <summary>Symbol: =&gt;</summary>
        RightArrow,
        /// <summary>Symbol: ::</summary>
        DoubleColon,
        /// <summary>Symbol: {</summary>
        OpenBrace,
        /// <summary>Symbol: }</summary>
        CloseBrace,
        /// <summary>Symbol: [</summary>
        OpenBracket,
        /// <summary>Symbol: ]</summary>
        CloseBracket,
        /// <summary>Symbol: (</summary>
        OpenParenthese,
        /// <summary>Symbol: )</summary>
        CloseParenthese,
        /// <summary>Symbol: .</summary>
        AccessOperator,
        /// <summary>Symbol: ,</summary>
        Comma,
        /// <summary>Symbol: :</summary>
        Colon,
        /// <summary>Symbol: ;</summary>
        Semicolon,
        /// <summary>Symbol: ~</summary>
        Tilde,

        /// <summary>Keyword: <see langword="abstract"/></summary>
        Abstract,
        /// <summary>Keyword: <see langword="add"/></summary>
        Add,
        /// <summary>Keyword: <see langword="alias"/></summary>
        Alias,
        /// <summary>Keyword: <see langword="and"/></summary>
        And,
        /// <summary>Keyword: <see langword="__arglist"/></summary>
        Arglist,
        /// <summary>Keyword: <see langword="ascending"/></summary>
        Ascending,
        /// <summary>Keyword: <see langword="async"/></summary>
        Async,
        /// <summary>Keyword: <see langword="as"/></summary>
        As,
        /// <summary>Keyword: <see langword="await"/></summary>
        Await,
        /// <summary>Keyword: <see langword="base"/></summary>
        Base,
        /// <summary>Keyword: <see langword="bool"/></summary>
        Bool,
        /// <summary>Keyword: <see langword="break"/></summary>
        Break,
        /// <summary>Keyword: <see langword="byte"/></summary>
        Byte,
        /// <summary>Keyword: <see langword="by"/></summary>
        By,
        /// <summary>Keyword: <see langword="case"/></summary>
        Case,
        /// <summary>Keyword: <see langword="catch"/></summary>
        Catch,
        /// <summary>Keyword: <see langword="char"/></summary>
        Char,
        /// <summary>Keyword: <see langword="checked"/></summary>
        Checked,
        /// <summary>Keyword: <see langword="class"/></summary>
        Class,
        /// <summary>Keyword: <see langword="const"/></summary>
        Const,
        /// <summary>Keyword: <see langword="continue"/></summary>
        Continue,
        /// <summary>Keyword: <see langword="decimal"/></summary>
        Decimal,
        /// <summary>Keyword: <see langword="default"/></summary>
        Default,
        /// <summary>Keyword: <see langword="delegate"/></summary>
        Delegate,
        /// <summary>Keyword: <see langword="descending"/></summary>
        Descending,
        /// <summary>Keyword: <see langword="double"/></summary>
        Double,
        /// <summary>Keyword: <see langword="do"/></summary>
        Do,
        /// <summary>Keyword: <see langword="dynamic"/></summary>
        Dynamic,
        /// <summary>Keyword: <see langword="else"/></summary>
        Else,
        /// <summary>Keyword: <see langword="enum"/></summary>
        Enum,
        /// <summary>Keyword: <see langword="equals"/></summary>
        Equals,
        /// <summary>Keyword: <see langword="event"/></summary>
        Event,
        /// <summary>Keyword: <see langword="explicit"/></summary>
        Explicit,
        /// <summary>Keyword: <see langword="extern"/></summary>
        Extern,
        /// <summary>Keyword: <see langword="false"/></summary>
        False,
        /// <summary>Keyword: <see langword="finally"/></summary>
        Finally,
        /// <summary>Keyword: <see langword="fixed"/></summary>
        Fixed,
        /// <summary>Keyword: <see langword="float"/></summary>
        Float,
        /// <summary>Keyword: <see langword="foreach"/></summary>
        Foreach,
        /// <summary>Keyword: <see langword="for"/></summary>
        For,
        /// <summary>Keyword: <see langword="from"/></summary>
        From,
        /// <summary>Keyword: <see langword="get"/></summary>
        Get,
        /// <summary>Keyword: <see langword="goto"/></summary>
        Goto,
        /// <summary>Keyword: <see langword="group"/></summary>
        Group,
        /// <summary>Keyword: <see langword="if"/></summary>
        If,
        /// <summary>Keyword: <see langword="implicit"/></summary>
        Implicit,
        /// <summary>Keyword: <see langword="interface"/></summary>
        Interface,
        /// <summary>Keyword: <see langword="internal"/></summary>
        Internal,
        /// <summary>Keyword: <see langword="into"/></summary>
        Into,
        /// <summary>Keyword: <see langword="int"/></summary>
        Int,
        /// <summary>Keyword: <see langword="in"/></summary>
        In,
        /// <summary>Keyword: <see langword="is"/></summary>
        Is,
        /// <summary>Keyword: <see langword="join"/></summary>
        Join,
        /// <summary>Keyword: <see langword="let"/></summary>
        Let,
        /// <summary>Keyword: <see langword="lock"/></summary>
        Lock,
        /// <summary>Keyword: <see langword="long"/></summary>
        Long,
        /// <summary>Keyword: <see langword="nameof"/></summary>
        Nameof,
        /// <summary>Keyword: <see langword="namespace"/></summary>
        Namespace,
        /// <summary>Keyword: <see langword="new"/></summary>
        New,
        /// <summary>Keyword: <see langword="notnull"/></summary>
        Notnull,
        /// <summary>Keyword: <see langword="not"/></summary>
        Not,
        /// <summary>Keyword: <see langword="null"/></summary>
        Null,
        /// <summary>Keyword: <see langword="object"/></summary>
        Object,
        /// <summary>Keyword: <see langword="on"/></summary>
        On,
        /// <summary>Keyword: <see langword="operator"/></summary>
        Operator,
        /// <summary>Keyword: <see langword="orderby"/></summary>
        Orderby,
        /// <summary>Keyword: <see langword="or"/></summary>
        Or,
        /// <summary>Keyword: <see langword="out"/></summary>
        Out,
        /// <summary>Keyword: <see langword="override"/></summary>
        Override,
        /// <summary>Keyword: <see langword="override"/></summary>
        Params,
        /// <summary>Keyword: <see langword="params"/></summary>
        Partial,
        /// <summary>Keyword: <see langword="partial"/></summary>
        Private,
        /// <summary>Keyword: <see langword="protected"/></summary>
        Protected,
        /// <summary>Keyword: <see langword="public"/></summary>
        Public,
        /// <summary>Keyword: <see langword="readonly"/></summary>
        Readonly,
        /// <summary>Keyword: <see langword="record"/></summary>
        Record,
        /// <summary>Keyword: <see langword="ref"/></summary>
        Ref,
        /// <summary>Keyword: <see langword="remove"/></summary>
        Remove,
        /// <summary>Keyword: <see langword="return"/></summary>
        Return,
        /// <summary>Keyword: <see langword="sbyte"/></summary>
        Sbyte,
        /// <summary>Keyword: <see langword="sealed"/></summary>
        Sealed,
        /// <summary>Keyword: <see langword="select"/></summary>
        Select,
        /// <summary>Keyword: <see langword="set"/></summary>
        Set,
        /// <summary>Keyword: <see langword="short"/></summary>
        Short,
        /// <summary>Keyword: <see langword="sizeof"/></summary>
        Sizeof,
        /// <summary>Keyword: <see langword="stackalloc"/></summary>
        Stackalloc,
        /// <summary>Keyword: <see langword="static"/></summary>
        Static,
        /// <summary>Keyword: <see langword="string"/></summary>
        String,
        /// <summary>Keyword: <see langword="struct"/></summary>
        Struct,
        /// <summary>Keyword: <see langword="switch"/></summary>
        Switch,
        /// <summary>Keyword: <see langword="this"/></summary>
        This,
        /// <summary>Keyword: <see langword="throw"/></summary>
        Throw,
        /// <summary>Keyword: <see langword="true"/></summary>
        True,
        /// <summary>Keyword: <see langword="try"/></summary>
        Try,
        /// <summary>Keyword: <see langword="typeof"/></summary>
        Typeof,
        /// <summary>Keyword: <see langword="uint"/></summary>
        Uint,
        /// <summary>Keyword: <see langword="ulong"/></summary>
        Ulong,
        /// <summary>Keyword: <see langword="unchecked"/></summary>
        Unchecked,
        /// <summary>Keyword: <see langword="unmanaged"/></summary>
        Unmanaged,
        /// <summary>Keyword: <see langword="unsafe"/></summary>
        Unsafe,
        /// <summary>Keyword: <see langword="ushort"/></summary>
        Ushort,
        /// <summary>Keyword: <see langword="using"/></summary>
        Using,
        /// <summary>Keyword: <see langword="var"/></summary>
        Var,
        /// <summary>Keyword: <see langword="virtual"/></summary>
        Virtual,
        /// <summary>Keyword: <see langword="void"/></summary>
        Void,
        /// <summary>Keyword: <see langword="volatile"/></summary>
        Volatile,
        /// <summary>Keyword: <see langword="when"/></summary>
        When,
        /// <summary>Keyword: <see langword="where"/></summary>
        Where,
        /// <summary>Keyword: <see langword="while"/></summary>
        While,
        /// <summary>Keyword: <see langword="yield"/></summary>
        Yield,

        /// <summary>Access on integer literals e.g.: 7.ToString()</summary>
        LiteralAccess,
        /// <summary>Byte order mark of a compilation unit</summary>
        ByteOrderMark,
        /// <summary>String interpolation symbol: {{</summary>
        DoubleCurlyOpenInside,
        /// <summary>String interpolation symbol: }}</summary>
        DoubleCurlyCloseInside,
        /// <summary>String interpolation symbol: {</summary>
        OpenBraceInside,
        /// <summary>String interpolation symbol: }</summary>
        CloseBraceInside,
        /// <summary>String interpolation regular character</summary>
        RegularCharInside,
        /// <summary>String interpolation symbol: ""</summary>
        VerbatiumDoubleQuoteInside,
        /// <summary>String interpolation symbol: "</summary>
        DoubleQuoteInside,
        /// <summary>String interpolation regular string</summary>
        RegularStringInside,
        /// <summary>String interpolation verbatium string</summary>
        VerbatiumStringInside,
        /// <summary>String interpolation format string</summary>
        FormatStringInside,
    }
}
