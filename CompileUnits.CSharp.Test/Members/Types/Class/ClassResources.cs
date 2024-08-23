namespace CompileUnits.CSharp.Test.Members.Types.Class
{
    internal static class ClassResources
    {
        private readonly static string EmptyClass = "class MyClass {}";

        public static readonly object[] ModifierConfigs =
        {
            new object[] { EmptyClass, nameof(IClass.AccessModifier), AccessModifier.None, },
            new object[] { $"public {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {EmptyClass}", nameof(IClass.AccessModifier), AccessModifier.PrivateProtected, },

            new object[] { EmptyClass, nameof(IClass.IsAbstract), false, },
            new object[] { $"abstract {EmptyClass}", nameof(IClass.IsAbstract), true, },
            new object[] { EmptyClass, nameof(IClass.IsStatic), false, },
            new object[] { $"static {EmptyClass}", nameof(IClass.IsStatic), true, },
            new object[] { EmptyClass, nameof(IClass.IsSealed), false, },
            new object[] { $"sealed {EmptyClass}", nameof(IClass.IsSealed), true, },
            new object[] { EmptyClass, nameof(IClass.IsRecord), false, },
            new object[] { $"record {EmptyClass}", nameof(IClass.IsRecord), true, },
            new object[] { "record MyClass{}", nameof(IClass.IsRecord), true, },
            new object[] { EmptyClass, nameof(IClass.IsAbstract), false, },
            new object[] { $"abstract {EmptyClass}", nameof(IClass.IsAbstract), true, },
            new object[] { EmptyClass, nameof(IClass.HasNewModifier), false, },
            new object[] { $"new {EmptyClass}", nameof(IClass.HasNewModifier), true, },
        };

        public static readonly object[] CollectionConfigs =
        {
            new object[] { $"[MyAttribute] {EmptyClass}", nameof(IClass.AttributeGroups) },
            new object[] { "class MyClass<T> { }", nameof(IClass.GenericTypeArguments) },
            new object[] { "class MyClass<T> where T : XY { }", nameof(IClass.Constraints) },
            new object[] { "class MyClass : BaseClass { }", nameof(IClass.Inheritance) },
            new object[] { "class MyClass { int _xy; }", nameof(IClass.Members) },
            new object[] { "class MyClass { int Xy { get; set; } }", nameof(IClass.Members) },
            new object[] { "class MyClass { int Xy() => 3; }", nameof(IClass.Members) },
            new object[] { "class MyClass { public MyClass() {} }", nameof(IClass.Members) },
            new object[] { "class MyClass { ~MyClass() {} }", nameof(IClass.Members) },
            new object[] { "class MyClass { int this[int idx] { get; set; } }", nameof(IClass.Members) },
            new object[] { "class MyClass { event PropertyChangedEventHandler PropertyChanged; }", nameof(IClass.Members) },
            new object[] { "class MyClass { event PropertyChangedEventHandler PropertyChanged { add { } remove { } } }", nameof(IClass.Members) },
            new object[] { "class MyClass { const string s = \"ABC\"; }", nameof(IClass.Members) },
            new object[] { "class MyClass { public static int operator+(MyClass lhs, int rhs) { } }", nameof(IClass.Members) },
            new object[] { "class MyClass { public static explicit operator bool(MyClass lhs) { } }", nameof(IClass.Members) },
            new object[] { "class MyClass { class MyNestedClass { } }", nameof(IClass.Members) },
            new object[] { "class MyClass { void XY(string x, int y) { } }", nameof(IClass.Members) },
            new object[] { "class MyClass { [DoesNothing(ignore = true, false)] void XY(string x, [MayBeNull] int y) { } }", nameof(IClass.Members) },
            new object[] { "class MyClass { public MyClass() : base(true) { } }", nameof(IClass.Members) },
        };
    }
}
