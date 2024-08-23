namespace CompileUnits.CSharp.Test.Members.Types.Struct
{
    internal class StructResources
    {
        private static readonly string EmptyStruct = "struct MyStruct {}";

        public static readonly object[] ModifierConfigs =
        {
            new object[] { EmptyStruct, nameof(IStruct.AccessModifier), AccessModifier.None, },
            new object[] { $"public {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {EmptyStruct}", nameof(IStruct.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"record {EmptyStruct}", nameof(IStruct.IsRecord), true, },
            new object[] { $"readonly {EmptyStruct}", nameof(IStruct.IsReadonly), true, },

            new object[] { EmptyStruct, nameof(IStruct.HasNewModifier), false, },
            new object[] { $"new {EmptyStruct}", nameof(IStruct.HasNewModifier), true, },
        };

        public static readonly object[] GenericTypeParameters =
        {
            new object[] { "struct MyStruct<T> { }", "T", Variance.None },
        };

        public static readonly object[] Inheritance =
        {
            new object[] { "struct MyStruct<[DoesNothing]T> { }", Array.Empty<string>() },
            new object[] { "struct MyStruct : IEquatable<IIface> { }", new[] { "IEquatable<IIface>" } },
            new object[] { "struct MyStruct<T> : ISomething { }", new[] { "ISomething" } },
            new object[] { "struct MyStruct<T> : IEquatable<IIface, T> { }", new[] { "IEquatable<IIface, T>" } },
            new object[] { "struct MyStruct : IEquatable<IIface<Tu>> { }", new[] { "IEquatable<IIface<Tu>>" } },
            new object[] { "struct MyStruct<T> : IEquatable<IIface<T>>, ISomething { }", new[] { "IEquatable<IIface<T>>", "ISomething" } },
        };

        public static readonly object[] CollectionConfigs =
        {
            new object[] { $"[MyAttribute(herbert: true)] {EmptyStruct}", nameof(IStruct.AttributeGroups) },
            new object[] { "struct MyStruct<T> { }", nameof(IStruct.GenericTypeArguments) },
            new object[] { "struct MyStruct<T> where T : XY { }", nameof(IStruct.Constraints) },
            new object[] { "struct MyStruct : BaseClass { }", nameof(IStruct.Inheritance) },
            new object[] { "struct MyStruct { int _xy; }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { int Xy { get; set; } }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { int Xy() => 3; }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { public MyStruct() {} }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { int this[int idx] { get; set; } }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { event PropertyChangedEventHandler PropertyChanged; }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { const string s = \"ABC\"; }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { public static int operator+(MyStruct lhs, int rhs) { } }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { public static explicit operator bool(MyStruct lhs) { } }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { struct MyNestedStruct { } }", nameof(IStruct.Members) },
            new object[] { "struct MyStruct { enum En { X = 1, Y } }", nameof(IStruct.Members)},
            new object[] { "struct MyStruct { interface MyInterface { } }", nameof(IStruct.Members)},
            new object[] { "struct MyStruct { delegate void MyDelegate(); }", nameof(IStruct.Members)},
            new object[] { "struct MyStruct { public void GetNothing(ref int x) { } }", nameof(IStruct.Members)},
            new object[] { "struct MyStruct { public void GetNothing(in int x) { } }", nameof(IStruct.Members)},
            new object[] { "struct MyStruct { public void GetNothing(out int x) { } }", nameof(IStruct.Members)},
            new object[] { "struct MyStruct { [DoesNothing] public void GetNothing(int x = 3) { } }", nameof(IStruct.Members)},
        };
    }
}
