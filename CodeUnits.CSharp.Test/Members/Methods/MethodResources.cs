namespace CodeUnits.CSharp.Test.Members.Methods
{
    internal class MethodResources
    {
        private static readonly string DefaultMethod = "int X() { }";

        private static string MethodWithReturnType(string type) => $"{type} X() {{ }}";

        public static readonly object[] MethodBodies =
        {
            "=> 3;",
            "{ return 3; }",
            "{ }"
        };

        public static readonly object[] ModifierConfigs =
        {
            new object[] { DefaultMethod, nameof(IMethod.AccessModifier), AccessModifier.None, },
            new object[] { $"public {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {DefaultMethod}", nameof(IMethod.AccessModifier), AccessModifier.PrivateProtected, },

            new object[] { DefaultMethod, nameof(IMethod.InheritanceModifier), InheritanceModifier.None, },
            new object[] { $"abstract void X();", nameof(IMethod.InheritanceModifier), InheritanceModifier.Abstract,},
            new object[] { $"virtual {DefaultMethod}", nameof(IMethod.InheritanceModifier), InheritanceModifier.Virtual,},
            new object[] { $"sealed {DefaultMethod}", nameof(IMethod.InheritanceModifier), InheritanceModifier.Sealed,},

            new object[] { DefaultMethod, nameof(IMethod.HasNewModifier), false, },
            new object[] { $"new {DefaultMethod}", nameof(IMethod.HasNewModifier), true, },
            new object[] { DefaultMethod, nameof(IMethod.IsStatic), false, },
            new object[] { $"static {DefaultMethod}", nameof(IMethod.IsStatic), true, },
        };

        public static object[] ReturnTypes =
        {
            new object[] { MethodWithReturnType("bool"), "bool" },
            new object[] { MethodWithReturnType("string"), "string" },
            new object[] { MethodWithReturnType("int"), "int" },
            new object[] { MethodWithReturnType("System\n\t.String"), "System.String" },
            new object[] { MethodWithReturnType("System.Collections.Generic.IEnumerable< T  >"), "System.Collections.Generic.IEnumerable<T>" },
            new object[] { MethodWithReturnType("IWhatever"), "IWhatever" },
            new object[] { MethodWithReturnType("MyClass"), "MyClass" },
            new object[] { MethodWithReturnType("double"), "double" },
            new object[] { MethodWithReturnType("Double"), "Double" },
        };
    }
}
