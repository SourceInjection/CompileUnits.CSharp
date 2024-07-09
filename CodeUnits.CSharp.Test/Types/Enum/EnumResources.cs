namespace CodeUnits.CSharp.Test.Types.Enum
{
    internal class EnumResources
    {
        private static readonly string AnyEnum = "enum En { X, Y }";

        public static object[] BaseTypes = 
        [
            new object[]{ "enum En : int { X, Y }", "int" },
            new object[]{ "enum En : ushort { X, Y }", "ushort" },
            new object[]{ "enum En : long { X, Y }", "long" },
            new object[]{ "enum En : byte { X, Y }", "byte" },
        ];

        public static readonly object[] ModifierConfigs =
        [
            new object[] { AnyEnum, nameof(IEnum.AccessModifier), AccessModifier.None, },
            new object[] { $"public {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.Public, },
            new object[] { $"internal {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.Internal, },
            new object[] { $"private {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.Private, },
            new object[] { $"protected {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.Protected, },
            new object[] { $"protected internal {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"internal protected {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.ProtectedInternal, },
            new object[] { $"protected private {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.PrivateProtected, },
            new object[] { $"private protected {AnyEnum}", nameof(IEnum.AccessModifier), AccessModifier.PrivateProtected, },

            new object[] { AnyEnum, nameof(IEnum.HasNewModifier), false, },
            new object[] { $"new {AnyEnum}", nameof(IEnum.HasNewModifier), true, },
        ];
    }
}
