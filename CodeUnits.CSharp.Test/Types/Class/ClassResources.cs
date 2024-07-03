namespace CodeUnits.CSharp.Test.Types.Class
{
    internal static class ClassResources
    {
        private readonly static string EmptyClass = "class MyClass {}";

        public static readonly object[] Configurations =
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
    }
}
