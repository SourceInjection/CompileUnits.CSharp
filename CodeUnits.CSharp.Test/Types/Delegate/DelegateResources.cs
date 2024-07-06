namespace CodeUnits.CSharp.Test.Types.Delegate
{
    internal static class DelegateResources
    {
        public static readonly object[] GenericTypeParameters =
        [
            new object[] { "delegate void Del<T>();", "T", Variance.None },
            new object[] { "delegate void Del<in T>();", "T", Variance.In },
            new object[] { "delegate void Del<out T>();", "T", Variance.Out },
        ];

        public static readonly object[] Parameters =
        [
            new object[] { "delegate void Del(bool b);", new[] { ("bool", "b", ParameterModifier.None) } },
            new object[] { "delegate void Del(bool b, MyClass xY);", new[] { ("bool", "b", ParameterModifier.None), ("MyClass", "xY", ParameterModifier.None) } },
        ];
    }
}
