namespace CodeUnits.CSharp.Test.Members.Types.Delegate
{
    internal static class DelegateResources
    {
        private static readonly string AnyDelegate = "delegate void Del();";

        public static readonly object[] ModifierConfigs =
        {
            new object[] { AnyDelegate, nameof(IDelegate.AccessModifier), AccessModifier.None, },
            new object[] { $"public {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {AnyDelegate}", nameof(IDelegate.AccessModifier), AccessModifier.PrivateProtected, },

            new object[] { AnyDelegate, nameof(IDelegate.HasNewModifier), false, },
            new object[] { $"new {AnyDelegate}", nameof(IDelegate.HasNewModifier), true, },
        };


        public static readonly object[] GenericTypeParameters =
        {
            new object[] { "delegate void Del<T>();", "T", Variance.None },
            new object[] { "delegate void Del<in T>();", "T", Variance.In },
            new object[] { "delegate void Del<out T>();", "T", Variance.Out },
        };

        public static readonly object[] Parameters =
        {
            new object[]
            {
                "delegate void Del(bool b);",
                new[]
                {
                    new ParameterInfo("bool", "b", ParameterModifier.None)
                }
            },
            new object[]
            {
                "delegate void Del(bool b, MyClass xY);", new[]
                {
                    new ParameterInfo("bool", "b", ParameterModifier.None),
                    new ParameterInfo("MyClass", "xY", ParameterModifier.None)
                }
            },
        };


        private static string DelegateWithReturnType(string type)
        {
            return $"delegate {type} Del();";
        }

        public static object[] ReturnTypes =
        {
            new object[] { DelegateWithReturnType("bool"), "bool" },
            new object[] { DelegateWithReturnType("string"), "string" },
            new object[] { DelegateWithReturnType("int"), "int" },
            new object[] { DelegateWithReturnType("System\n\t.String"), "System.String" },
            new object[] { DelegateWithReturnType("System.Collections.Generic.IEnumerable< T  >"), "System.Collections.Generic.IEnumerable<T>" },
            new object[] { DelegateWithReturnType("IWhatever"), "IWhatever" },
            new object[] { DelegateWithReturnType("MyClass"), "MyClass" },
            new object[] { DelegateWithReturnType("double"), "double" },
            new object[] { DelegateWithReturnType("Double"), "Double" },
        };

        public static object[] Constraints =
        {
            new object[] { "delegate void Del<T>() where T : class;", "T" },
            new object[] { "delegate void Del<T>() where T : class, new();", "T" },
            new object[] { "delegate void Del<T>() where T : string;", "T" },
        };
    }
}
