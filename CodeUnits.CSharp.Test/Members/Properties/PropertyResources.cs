namespace CodeUnits.CSharp.Test.Members.Properties
{
    internal static class PropertyResources
    {
        private static readonly string DefaultProperty = "int X { get; set; }";

        private static string PropertyWithReturnType(string type) => $"{type} X {{ get; set; }}";


        public static readonly object[] ModifierConfigs =
        {
            new object[] { DefaultProperty, nameof(IProperty.AccessModifier), AccessModifier.None, },
            new object[] { $"public {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {DefaultProperty}", nameof(IProperty.AccessModifier), AccessModifier.PrivateProtected, },

            new object[] { DefaultProperty, nameof(IProperty.InheritanceModifier), InheritanceModifier.None, },
            new object[] { $"abstract {DefaultProperty}", nameof(IProperty.InheritanceModifier), InheritanceModifier.Abstract,},
            new object[] { $"virtual {DefaultProperty}", nameof(IProperty.InheritanceModifier), InheritanceModifier.Virtual,},
            new object[] { $"sealed {DefaultProperty}", nameof(IProperty.InheritanceModifier), InheritanceModifier.Sealed,},

            new object[] { DefaultProperty, nameof(IProperty.HasRefModifier), false, },
            new object[] { $"ref {DefaultProperty}", nameof(IProperty.HasRefModifier), true, },
            new object[] { DefaultProperty, nameof(IProperty.HasNewModifier), false, },
            new object[] { $"new {DefaultProperty}", nameof(IProperty.HasNewModifier), true, },
            new object[] { DefaultProperty, nameof(IProperty.IsStatic), false, },
            new object[] { $"static {DefaultProperty}", nameof(IProperty.IsStatic), true, },
        };

        public static object[] ReturnTypes =
        {
            new object[] { PropertyWithReturnType("bool"), "bool" },
            new object[] { PropertyWithReturnType("string"), "string" },
            new object[] { PropertyWithReturnType("int"), "int" },
            new object[] { PropertyWithReturnType("System\n\t.String"), "System.String" },
            new object[] { PropertyWithReturnType("System.Collections.Generic.IEnumerable< T  >"), "System.Collections.Generic.IEnumerable<T>" },
            new object[] { PropertyWithReturnType("IWhatever"), "IWhatever" },
            new object[] { PropertyWithReturnType("MyClass"), "MyClass" },
            new object[] { PropertyWithReturnType("double"), "double" },
            new object[] { PropertyWithReturnType("Double"), "Double" },
        };

        public static object[] Initializers =
        {
            "int X { set; } = 3;",
            "string[] SA { get; } = { \"A\", \"B\" };"
        };
    }
}
