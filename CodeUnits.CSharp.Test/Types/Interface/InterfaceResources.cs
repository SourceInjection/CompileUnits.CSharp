namespace CodeUnits.CSharp.Test.Types.Interface
{
    internal class InterfaceResources
    {
        private static readonly string EmptyInterface = "interface IIface {}";

        public static readonly object[] ModifierConfigs =
        [
            new object[] { EmptyInterface, nameof(IInterface.AccessModifier), AccessModifier.None, },
            new object[] { $"public {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {EmptyInterface}", nameof(IInterface.AccessModifier), AccessModifier.PrivateProtected, },

            new object[] { EmptyInterface, nameof(IInterface.HasNewModifier), false, },
            new object[] { $"new {EmptyInterface}", nameof(IInterface.HasNewModifier), true, },
        ];

        public static readonly object[] GenericTypeParameters =
        [
            new object[] { "interface IIface<T> { }", "T", Variance.None },
            new object[] { "interface IIface<in T> { }", "T", Variance.In },
            new object[] { "interface IIface<out T> { }", "T", Variance.Out },
        ];

        interface IIface<T> : IEquatable<IIface<T>> { }

        public static readonly object[] Inheritance =
        [
            new object[] { "interface IIface<T> { }", Array.Empty<string>() },
            new object[] { "interface IIface : IEquatable<IIface> { }", new[] { "IEquatable<IIface>" } },
            new object[] { "interface IIface<T> : ISomething { }", new[] { "ISomething" } },
            new object[] { "interface IIface<T> : IEquatable<IIface> { }", new[] { "IEquatable<IIface>" } },
            new object[] { "interface IIface<T> : IEquatable<IIface<T>> { }", new[] { "IEquatable<IIface<T>>" } },
            //new object[] { "interface IIface<T> : IEquatable<IIface<T>>, ISomething { }", new[] { "IEquatable<IIface<T>>", "ISomething" } },
        ];
    }
}
